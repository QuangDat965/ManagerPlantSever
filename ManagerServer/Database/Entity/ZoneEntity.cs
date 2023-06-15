using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerServer.Database.Entity
{
    public class ZoneEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("Farm")]
        public int? FarmId { get; set; }
        [NotMapped]
        public FarmEntity? Farm { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DateCreate { get; set; } = DateTime.Now;
        public DateTime? DateUpdate { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public List<MeasuringDeviceEntity>? MeasuringDevices { get; set; }
        public List<DeviceActionEntity>? DeviceActions { get; set; }
    }
}
