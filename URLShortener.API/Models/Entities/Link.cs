namespace TinyLink.API.Models.Entities
{
    public class Link : Entity
    {
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public string Hash { get; set; }
    }
}
