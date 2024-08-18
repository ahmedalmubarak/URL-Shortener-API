using Microsoft.AspNetCore.Mvc;

namespace TinyLink.API.Models
{
    public class CreateTinyLinkRequest
    {
        [FromBody]
        public string OriginalUrl { get; set; }

    }
    public class CreateTinyLinkCommand
    {
        public string OriginalUrl { get; set; }

        public string Device { get; set; }
        public string IPAddress { get; set; }

    }
}
