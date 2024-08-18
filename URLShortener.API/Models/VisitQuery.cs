namespace TinyLink.API.Models
{
    public class VisitQuery
    {
        public Guid LinkId { get; set; }
        public string Device { get; set; }
        public string IPAddress { get; set; }
    }
}
