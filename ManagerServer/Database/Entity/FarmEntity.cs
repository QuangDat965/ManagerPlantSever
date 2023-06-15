using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerServer.Database.Entity
{
    public class FarmEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("Owner")]
        public string? OwnerId { get; set; }
        [NotMapped]
        public AppUser? Owner { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DateCreate { get; set; } = DateTime.Now;
        public DateTime? DateUpdate { get; set; }
        public string? Image { get; set; }
        public string? Adress { get; set; }
        public List<ZoneEntity>? Zones { get; set; }

    }
}
