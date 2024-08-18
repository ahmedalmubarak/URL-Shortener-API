using TinyLink.API.Models.Entities;

namespace TinyLink.API.Infrastrucure.Repository
{
    public class TinyLinkRepositry : ITinyLinkRepository
    {
        public Task<Link> AddLink(Link link)
        {
            throw new NotImplementedException();
        }

        public Task<Link> GetTinyLink(string tinyLink)
        {
            throw new NotImplementedException();
        }
    }
}
