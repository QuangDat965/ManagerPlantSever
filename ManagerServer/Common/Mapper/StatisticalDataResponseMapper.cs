using ManagerServer.Database.Entity;
using ManagerServer.Model.StatisticalDataResponse;

namespace ManagerServer.Common.Mapper
{
    public static class StatisticalDataResponseMapper
    {
        public static StatisticalDataResponseModel StatisticalDataResponseMapping(this StatisticalDataResponseForHourEntity entity)
        {
            return new StatisticalDataResponseModel ()
            {
                AvgValue = entity.AvgValue,
                DateRetrive = entity.DateRetrive,
                //DeviceMeasureId = entity.DeviceMeasureId,
                MaxValue = entity.MaxValue,
                MinValue = entity.MinValue,
                TotalValue = entity.TotalValue,
                ValueDate = entity.ValueDate
            };
        }
    }
}
