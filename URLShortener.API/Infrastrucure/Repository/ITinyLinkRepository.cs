using TinyLink.API.Models.Entities;

namespace TinyLink.API.Infrastrucure.Repository
{
    public interface ITinyLinkRepository : IBaseRepository<Link>
    {
        Task<Link> GetTinyLinkByHash(string hash);
    }
}
