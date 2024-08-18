using Microsoft.AspNetCore.Mvc;

namespace TinyLink.API.Models
{
    public class TinyLinkRequest
    {

        [FromQuery]
        public string TinyLink { get; set; }
    }
}
