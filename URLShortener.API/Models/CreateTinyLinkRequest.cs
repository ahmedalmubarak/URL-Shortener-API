using Microsoft.AspNetCore.Mvc;

namespace TinyLink.API.Models
{
    public class CreateTinyLinkRequest
    {
        [FromBody]
        public string OriginalUrl { get; set; }

    }
}
