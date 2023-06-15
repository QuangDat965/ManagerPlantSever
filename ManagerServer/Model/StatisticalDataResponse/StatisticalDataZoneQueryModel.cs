using ManagerServer.Common.Enum;

namespace ManagerServer.Model.StatisticalDataResponse
{
    public class StatisticalDataZoneQueryModel
    {
        public int ZoneId { get; set; }
        public int FarmId { get; set; }
        public StatisticalPeriod Period { get; set; }
    }
}
