using Common.Model.Farm;
using ManagerServer.Database.Entity;

namespace Common.Mapper
{
    public static class FarmMapper
    {
        public static FarmDisplayModel ToFarmModel(this FarmEntity entity)
        {
            return new FarmDisplayModel ()
            {
                Id = entity.Id,
                Decription = entity.Description,
                OwnerId = entity.OwnerId,
                Name = entity.Name,
            };
        }
    }
}
