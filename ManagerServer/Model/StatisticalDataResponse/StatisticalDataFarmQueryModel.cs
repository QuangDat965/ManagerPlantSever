using ManagerServer.Common.Enum;

namespace ManagerServer.Model.StatisticalDataResponse
{
    public class StatisticalDataFarmQueryModel
    {
        public int FarmId { get; set; }
        public StatisticalPeriod Period { get; set; }
    }
}
