using TinyLink.API.Models;
using TinyLink.API.Models.Entities;
using TinyLink.API.Utilities;

namespace TinyLink.API.Services
{
    public class TinyLinkService
    {
        private string baseUrl = "https://localhost:7119/";
        public Link CreateTinyLink(CreateTinyLinkCommand command)
        {
            var hash = HashHelper.GenrateHash(command.OriginalUrl);
            var link = new Link()
            {
                OriginalUrl = command.OriginalUrl,
                Hash = hash,
                ShortenedUrl = $"{baseUrl}{hash}"
            };
            return link;
        }

        public string GetOriginalUrl(TinyLinkQuery query)
        {
            return "";
        }
    }
}
