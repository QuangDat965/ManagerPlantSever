using ManagerServer.Common.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerServer.Database.Entity
{
    public class StatisticalDataResponseForHourEntity
    {
        public int Id { get; set; }
        [ForeignKey ("StatisticalDataResponse")]
        public int? DeviceMeasureId { get; set; }
        [NotMapped]
        public MeasuringDeviceEntity? StatisticalDataResponse { get; set; }
        public DeviceType deviceType { get; set; }
        public DateTime ValueDate { get; set; } = DateTime.Now; // thoi gian tao => cuối mỗi giờ
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double AvgValue { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double TotalValue { get; set; }
        public DateTime DateRetrive { get; set; }
    }
}
