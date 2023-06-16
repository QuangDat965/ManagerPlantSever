using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerServer.Database.Entity
{
    public class DeviceActionLogEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("DeviceAction")]
        public int? DeviceActionId { get; set; }
        public DeviceActionEntity? DeviceAction { get; set; }
        public DateTime ValueDate { get; set; }
        public double ValueMin { get; set; }
        public double ValueMax { get; set; }
        public bool IsAuto { get; set; } = false;
        public bool NumberMinChangeAuto { get; set; }
        public bool NumberMaxChangeAuto { get; set; }
    }
}
