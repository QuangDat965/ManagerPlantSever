using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerServer.Database.Entity
{
    public class DeviceActionEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsProblem { get; set; } = false;
        public bool IsAction { get; set; } = true;
        public string? Image { get; set; }
        public string? Address { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        [ForeignKey ("Zone")]
        public int ZoneId { get; set; }
        [NotMapped]
        public ZoneEntity? Zone { get; set; }
        public List<DeviceActionLogEntity>? DeviceActionLog { get; set; }
    }
}
