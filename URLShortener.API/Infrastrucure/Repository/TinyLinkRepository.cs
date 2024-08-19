using Microsoft.EntityFrameworkCore;
using TinyLink.API.Models.Entities;

namespace TinyLink.API.Infrastrucure.Repository
{
    public class TinyLinkRepository : BaseRepository<Link>, ITinyLinkRepository
    {
        protected ApplicationDbContext _dbContext;

        public TinyLinkRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Link> GetTinyLinkByHash(string hash)
        {
            return await _dbContext.Links.FirstOrDefaultAsync(x => x.Hash == hash);
        }

    }
}
