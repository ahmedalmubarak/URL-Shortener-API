using TinyLink.API.Models;
using TinyLink.API.Models.Entities;

namespace TinyLink.API.Services
{
    public interface ITinyLinkService
    {
        Task<Link> CreateTinyLink(CreateTinyLinkCommand command);
        Task<string> GetOriginalLink(TinyLinkQuery query);
        Task RecordVisits(TinyLinkQuery query);
    }
}
