using System.ComponentModel.DataAnnotations;

namespace TinyLink.API.Models.Entities
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime ModeifiedDateTime { get; set; } = DateTime.UtcNow;
        public bool Deactivated { get; set; }
    }
}
