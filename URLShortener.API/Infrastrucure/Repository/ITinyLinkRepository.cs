using TinyLink.API.Models.Entities;

namespace TinyLink.API.Infrastrucure.Repository
{
    public interface ITinyLinkRepository
    {
        Task<Link> AddLink(Link link);
        Task<Link> GetTinyLinkByHash(string hash);
        Task<bool> SaveChangesAsync();
        Task<Link> UpdateLink(Link link);
    }
}
