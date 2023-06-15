using ManagerServer.Common.Mapper;
using ManagerServer.Database;
using ManagerServer.Model.Device;
using ManagerServer.Model.ResponeModel;
using Microsoft.EntityFrameworkCore;

namespace ManagerServer.Service.DeviceActionService
{
    public sealed class DeviceActionService : IDeviceActionService
    {
        private readonly ManagerDbContext dbContext;

        public DeviceActionService(ManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ResponseModel<bool>> DeleteDeviceAction(RemoveDeviceActionModel requestModel)
        {
            try
            {
                var deviceAction = await dbContext.DeviceActionEntities.Where (q => requestModel.ZoneId == q.ZoneId && requestModel.DeviceActionId == q.Id).FirstOrDefaultAsync ();
                if ( deviceAction != null )
                {
                    dbContext.DeviceActionEntities.Remove (deviceAction);
                }
                else
                {
                    return new ResponseModel<bool> ()
                    {
                        code = 1,
                        message = "Not found object",
                        data = false
                    };
                }
                var result = await dbContext.SaveChangesAsync ();
                return new ResponseModel<bool> ()
                {
                    code = 1,
                    message = "Udpate Success",
                    data = result > 0,
                };
            }
            catch ( Exception ex )
            {
                return new ResponseModel<bool> ()
                {
                    code = 0,
                    message = "Udpate fall " + ex.Message,
                    data = false
                };
            }
        }


        public async Task<ResponseModel<List<DeviceActionDisplayModel>>> GetDeviceActionByZoneId(int zoneId)
        {
            try
            {
                var deviceActionQueryable = from data in dbContext.DeviceActionEntities
                                            where zoneId == data.ZoneId
                                            select data.DeviceActionMapping ();
                return new ResponseModel<List<DeviceActionDisplayModel>> ()
                {
                    code = 1,
                    message = "Success",
                    data = await deviceActionQueryable.ToListAsync (),
                };
            }
            catch ( Exception ex )
            {
                return new ResponseModel<List<DeviceActionDisplayModel>> ()
                {
                    code = 0,
                    message = "Fall" + ex.Message,
                };
            }
        }

        public async Task<ResponseModel<bool>> TurnOffDeviceAction(RemoveDeviceActionModel requestModel)
        {
            try
            {
                var deviceAction = await dbContext.DeviceActionEntities.Where (q => requestModel.ZoneId == q.ZoneId && requestModel.DeviceActionId == q.Id).FirstOrDefaultAsync ();
                if ( deviceAction != null )
                {
                    if ( deviceAction.IsAction )
                    {
                        deviceAction.IsAction = false;
                    }
                }
                else
                {
                    return new ResponseModel<bool> ()
                    {
                        code = 0,
                        message = "Not found object",
                        data = false
                    };
                }
                var result = await dbContext.SaveChangesAsync ();
                return new ResponseModel<bool> ()
                {
                    code = 1,
                    message = "Udpate Success",
                    data = result > 0,
                };
            }
            catch ( Exception ex )
            {
                return new ResponseModel<bool> ()
                {
                    code = 0,
                    message = "Udpate fall " + ex.Message,
                    data = false
                };
            }
        }

        public async Task<ResponseModel<bool>> TurnOnDeviceAction(RemoveDeviceActionModel requestModel)
        {
            try
            {
                var deviceAction = await dbContext.DeviceActionEntities.Where (q => requestModel.ZoneId == q.ZoneId && requestModel.DeviceActionId == q.Id).FirstOrDefaultAsync ();
                if ( deviceAction != null )
                {
                    if ( !deviceAction.IsAction )
                    {
                        deviceAction.IsAction = true;
                    }
                }
                else
                {
                    return new ResponseModel<bool> ()
                    {
                        code = 0,
                        message = "Not found object",
                        data = false
                    };
                }
                var result = await dbContext.SaveChangesAsync ();
                return new ResponseModel<bool> ()
                {
                    code = 1,
                    message = "Udpate Success",
                    data = result > 0,
                };
            }
            catch ( Exception ex )
            {
                return new ResponseModel<bool> ()
                {
                    code = 0,
                    message = "Udpate fall " + ex.Message,
                    data = false
                };
            }
        }

        public async Task<ResponseModel<bool>> UpdateDeviceAction(DeviceActionUpdateModel updateModel)
        {
            try
            {
                var deviceAction = await dbContext.DeviceActionEntities.Where (q => updateModel.zoneId == q.ZoneId && updateModel.id == q.Id).FirstOrDefaultAsync ();
                if ( deviceAction != null )
                {
                    if ( !string.IsNullOrEmpty (updateModel.nameDevice) ) deviceAction.Name = updateModel.nameDevice;
                    if ( !string.IsNullOrEmpty (updateModel.descriptionDevice) ) deviceAction.Description = updateModel.descriptionDevice;
                    if ( !string.IsNullOrEmpty (updateModel.image) ) deviceAction.Image = updateModel.image;
                    if ( updateModel.isAction ) deviceAction.IsAction = true;
                    if ( updateModel.isProblem ) deviceAction.IsProblem = true;
                    if ( updateModel.zoneId != deviceAction.ZoneId ) deviceAction.ZoneId = deviceAction.ZoneId;
                }
                else
                {
                    return new ResponseModel<bool> ()
                    {
                        code = 0,
                        message = "Not found object",
                        data = false
                    };
                }
                var result = await dbContext.SaveChangesAsync ();
                return new ResponseModel<bool> ()
                {
                    code = 1,
                    message = "Udpate Success",
                    data = result > 0,
                };
            }
            catch ( Exception ex )
            {
                return new ResponseModel<bool> ()
                {
                    code = 0,
                    message = "Udpate fall " + ex.Message,
                    data = false
                };
            }
        }
    }
}
