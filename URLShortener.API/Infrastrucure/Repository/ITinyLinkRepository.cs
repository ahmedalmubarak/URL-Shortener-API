using TinyLink.API.Models.Entities;

namespace TinyLink.API.Infrastrucure.Repository
{
    public interface ITinyLinkRepository
    {
        Task<Link> AddLink(Link link);
        Task<Link> GetTinyLink(string tinyLink);
        Task<bool> SaveChanges();
        Task<Link> UpdateLink(Link link);
    }
}
