using ManagerServer.Common.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerServer.Database.Entity
{
    public class StatisticalDataResponseForHourEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("StatisticalDataResponse")]
        public string? DeviceMeasureId { get; set; }
        [NotMapped]
        public MeasuringDeviceEntity? StatisticalDataResponse { get; set; }
        public DeviceType DeviceType { get; set; }
        public DateTime ValueDate { get; set; } = DateTime.Now; // thoi gian tao => cuối mỗi giờ
        public double AvgValue { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double TotalValue { get; set; }
        public DateTime DateRetrive { get; set; }
    }
}
