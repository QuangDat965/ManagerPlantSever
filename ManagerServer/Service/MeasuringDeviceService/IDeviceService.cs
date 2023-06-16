using ManagerServer.Database.Entity;
using ManagerServer.Model.Device;
using ManagerServer.Model.ResponeModel;

namespace ManagerServer.Service.MeasuringDeviceService
{
    public interface IDeviceService
    {
        Task<List<MeasuringDeviceEntity>> GetAllDevice();
        Task<MeasuringDeviceEntity> GetById(DeviceRequestModel requestModel);
        Task<ResponseModel<bool>> SetDeviceToZone(DeviceRequestModel requestModel);
        Task<ResponseModel<List<MeasuringDeviceEntity>>> GetDeviceActive(DeviceRequestModel requestModel);
        Task<ResponseModel<List<MeasuringDeviceEntity>>> GetDeviceByZoneId(DeviceRequestModel requestModel);
        Task<ResponseModel<bool>> CreateDevice(MeasuringDeviceCreateModel requestModel);
    }
}
