using Microsoft.AspNetCore.Mvc;

namespace TinyLink.API.Models
{
    public class TinyLinkRequest
    {

        [FromQuery]
        public string TinyLink { get; set; }
    }
    public class TinyLinkQuery
    {
        public string TinyLink { get; set; }

        public string Device { get; set; }
        public string IPAddress { get; set; }
    }
}
