using ManagerServer.Common.Enum;

namespace ManagerServer.Model.Device
{
    public class MeasuringDeviceCreateModel
    {
        public int? ZoneId { get; set; }
        public string? Name { get; set; }
        public DeviceType deviceType { get; set; } = DeviceType.Unknown;
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public DateTime? DateCreate { get; set; } = DateTime.Now;
        public DateTime? DateUpdate { get; set; }
        public bool? IsActive { get; set; } = true;
        public bool? IsProblem { get; set; } = false;
        // Khóa tới Device response
        public int? DeviceActionLogId { get; set; }
    }
}
