using ManagerServer.Database.Entity;
using ManagerServer.Model.Device;

namespace ManagerServer.Common.Mapper
{
    public static class DeviceActionMapper
    {
        public static DeviceActionDisplayModel DeviceActionMapping(this DeviceActionEntity entity)
        {
            return new DeviceActionDisplayModel ()
            {
                Id = entity.Id,
                DescriptionDevice = entity.Description,
                IsAction = entity.IsAction,
                IsProblem = entity.IsProblem,
                NameDevice = entity.Name,
                ZoneId = entity.ZoneId,
            };
        }
    }
}
