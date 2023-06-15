using ManagerServer.Database;
using ManagerServer.Database.Entity;
using ManagerServer.Model.Device;
using ManagerServer.Model.ResponeModel;
using Microsoft.EntityFrameworkCore;

namespace ManagerServer.Service.DeviceService
{
    public class DeviceService : IDeviceService
    {
        private readonly ManagerDbContext dbContext;

        public DeviceService(ManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<MeasuringDeviceEntity>> GetAllDevice()
        {
            var result = await dbContext.MeasuringDeviceEntities.ToListAsync ();
            return result;
        }

        public async Task<MeasuringDeviceEntity> GetById(DeviceRequestModel requestModel)
        {
            return await dbContext.MeasuringDeviceEntities.FirstOrDefaultAsync (p => p.Id == requestModel.DeviceId);
        }

        public async Task<ResponseModel<List<MeasuringDeviceEntity>>> GetDeviceAtive(DeviceRequestModel requestModel)
        {
            try
            {
                return new ResponseModel<List<MeasuringDeviceEntity>> ()
                {
                    code = 1,
                    message = "Get Sucsess",
                    data = await (from data in dbContext.MeasuringDeviceEntities
                                  where data.IsActive == true
                                  select data).ToListAsync ()

                };
            }
            catch ( Exception ex )
            {
                return new ResponseModel<List<MeasuringDeviceEntity>> ()
                {
                    code = 0,
                    message = ex.Message,
                    data = null

                };
            }

        }

        public async Task<ResponseModel<List<MeasuringDeviceEntity>>> GetDeviceByZoneId(DeviceRequestModel requestModel)
        {
            try
            {
                IQueryable<MeasuringDeviceEntity> queryDevice = dbContext.MeasuringDeviceEntities.Where (q => q.ZoneId == requestModel.ZoneId).AsNoTracking ().AsQueryable ();
                string searchTerm = requestModel.searchTerm.ToLower ().Trim ();
                if ( !string.IsNullOrEmpty (requestModel.searchTerm) )
                {
                    queryDevice = queryDevice.Where (q => q.Name.ToLower ().Contains (searchTerm) || q.Description.ToLower ().Contains (searchTerm));
                }
                if ( requestModel.filterType != Common.Enum.FilterType.None )
                {
                    switch ( requestModel.filterType )
                    {
                        case Common.Enum.FilterType.SortByA_Z:
                            queryDevice = queryDevice.OrderBy (q => q.Name);
                            break;
                        case Common.Enum.FilterType.SortByA_ZReverse:
                            queryDevice = queryDevice.OrderByDescending (q => q.Name);
                            break;
                        case Common.Enum.FilterType.SortByDate:
                            queryDevice = queryDevice.OrderBy (q => q.DateCreate);
                            break;
                        case Common.Enum.FilterType.SortByDateReverse:
                            queryDevice = queryDevice.OrderByDescending (q => q.DateCreate);
                            break;
                    }
                }
                return new ResponseModel<List<MeasuringDeviceEntity>> ()
                {
                    code = 1,
                    message = "Get Sucsess",
                    data = await queryDevice.ToListAsync ()

                };
            }
            catch ( Exception ex )
            {
                return new ResponseModel<List<MeasuringDeviceEntity>> ()
                {
                    code = 0,
                    message = ex.Message,
                    data = null

                };
            }
        }

        public async Task<ResponseModel<bool>> SetDeviceToZone(DeviceRequestModel requestModel)
        {
            try
            {
                var device = await dbContext.MeasuringDeviceEntities.FirstOrDefaultAsync (p => p.Id == requestModel.DeviceId);
                if ( device != null )
                {
                    device.ZoneId = requestModel.ZoneId;
                }
                else
                {
                    return new ResponseModel<bool> ()
                    {
                        code = 0,
                        message = "Device not found",
                        data = false,

                    };
                }
                await dbContext.SaveChangesAsync ();
                return new ResponseModel<bool> ()
                {
                    code = 1,
                    message = "Set Sucsess",
                    data = true,

                };
            }
            catch ( Exception ex )
            {
                return new ResponseModel<bool> ()
                {
                    code = 0,
                    message = ex.Message,
                    data = false

                };
            }
        }
    }
}
