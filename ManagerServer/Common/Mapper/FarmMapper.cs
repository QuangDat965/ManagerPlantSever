using Common.Model.Farm;
using ManagerServer.Database.Entity;

namespace Common.Mapper
{
    public static class FarmMapper
    {
        public static FarmDisplayModel FromObject(object obj)
        {
            var dst = new FarmDisplayModel();
            var typ = typeof(FarmDisplayModel);

            foreach (var property in obj.GetType().GetProperties())
            {
                var value = property.GetValue(obj);
                if (value != null)
                {
                    var p = typ.GetProperty(property.Name);
                    if (p != null)
                    {
                        p.SetValue(dst, value, null);
                    }
                }
            }
            return dst;
        }
        public static FarmDisplayModel ToFarmModel(this FarmEntity entity)
        {
            return new FarmDisplayModel()
            {
                Id = entity.Id,
                Decription = entity.Description,
                OwnerId = entity.OwnerId,
                Name = entity.Name,
            };
        }
    }
}
