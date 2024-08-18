using Microsoft.EntityFrameworkCore;
using TinyLink.API.Models;
using TinyLink.API.Models.Entities;

namespace TinyLink.API.Infrastrucure.Repository
{
    public class VisitRepository(ApplicationDbContext _dbContext) : IVisitRepository
    {
        public async Task<Visit> AddVisit(Visit visit)
        {
            var response = await _dbContext.Visits.AddAsync(visit);
            SaveChangesAsync();
            return response.Entity;

        }

        public Task<Visit> GetVisitByQuery(VisitQuery query)
        {
            return _dbContext.Visits.FirstOrDefaultAsync(
                x => x.LinkId == query.LinkId &&
                x.IPAddress == query.IPAddress &&
                x.Device == query.Device);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Visit> UpdateVisit(Visit visit)
        {
            var response = _dbContext.Visits.Update(visit);
            await SaveChangesAsync();
            return response.Entity;

        }
    }
}
