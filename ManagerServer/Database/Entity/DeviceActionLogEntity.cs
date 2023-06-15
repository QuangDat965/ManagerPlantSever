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
        [ForeignKey ("MeasuringDevice")]
        public int? DeviceMeasureId { get; set; }
        public MeasuringDeviceEntity? MeasuringDevice { get; set; }
        public DateTime ValueDate { get; set; }
        public double ValueDeviceMeasure { get; set; }
        public bool IsAuto { get; set; } = false;
        public bool NumberChangeAuto { get; set; }
    }
}
