using Microsoft.EntityFrameworkCore;
using TinyLink.API.Models;
using TinyLink.API.Models.Entities;

namespace TinyLink.API.Infrastrucure.Repository
{
    public class VisitRepository : BaseRepository<Visit>, IVisitRepository
    {
        protected ApplicationDbContext _dbContext;

        public VisitRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public Task<Visit> GetVisitByQuery(VisitQuery query)
        {
            return _dbContext.Visits.FirstOrDefaultAsync(
                x => x.LinkId == query.LinkId &&
                x.IPAddress == query.IPAddress &&
                x.Device == query.Device);
        }

    }
}
