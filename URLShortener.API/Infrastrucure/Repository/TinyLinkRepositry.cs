using Microsoft.EntityFrameworkCore;
using TinyLink.API.Models.Entities;

namespace TinyLink.API.Infrastrucure.Repository
{
    public class TinyLinkRepositry(ApplicationDbContext _dbContext) : ITinyLinkRepository
    {
        public async Task<Link> AddLink(Link link)
        {
            var response = await _dbContext.Links.AddAsync(link);
            await SaveChangesAsync();
            return response.Entity;

        }

        public Task<Link> GetTinyLinkByHash(string hash)
        {
            return _dbContext.Links.FirstOrDefaultAsync(x => x.Hash == hash);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Link> UpdateLink(Link link)
        {
            var response = _dbContext.Links.Update(link);
            await SaveChangesAsync();
            return response.Entity;
        }
    }
}
