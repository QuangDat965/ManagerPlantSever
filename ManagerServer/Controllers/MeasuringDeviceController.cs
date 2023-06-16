using ManagerServer.Database.Entity;
using ManagerServer.Model.Device;
using ManagerServer.Model.ResponeModel;
using ManagerServer.Service.MeasuringDeviceService;
using Microsoft.AspNetCore.Mvc;

namespace ManagerServer.Controllers
{
    [ApiController, Route ("api/[controller]")]
    public class MeasuringDeviceController : ControllerBase
    {
        private readonly IDeviceService service;

        public MeasuringDeviceController(IDeviceService service)
        {
            this.service = service;
        }
        [HttpGet, Route ("get-all")]
        public async Task<List<MeasuringDeviceEntity>> GetAllDevice()
        {
            return await service.GetAllDevice ();
        }
        // SetZone cho Measuring device
        [HttpPost, Route ("setzone")]
        public async Task<ResponseModel<bool>> SetZone([FromBody] DeviceRequestModel requestModel)
        {
            return await service.SetDeviceToZone (requestModel);
        }
        [HttpPost, Route ("getdeviceative")]
        public async Task<ResponseModel<List<MeasuringDeviceEntity>>> GetDeviceAtive([FromBody] DeviceRequestModel requestModel)
        {
            return await service.GetDeviceActive (requestModel);
        }
        // Lấy ra Device By ZOne Id
        [HttpPost, Route ("getdevicebyzoneid")]
        public async Task<ResponseModel<List<MeasuringDeviceEntity>>> GetDeviceByZoneId([FromBody] DeviceRequestModel requestModel)
        {
            return await service.GetDeviceByZoneId (requestModel);
        }
        // Dùng để tạo mới 1 Measuring Device
        [HttpPost ("AddDevice")]
        public async Task<ResponseModel<bool>> CreateDevice(MeasuringDeviceCreateModel requestModel)
        {
            return await service.CreateDevice (requestModel);
        }

    }
}
