namespace ManagerServer.Model.Device
{
    public class DeviceRequestModel : BaseQueryModel
    {
        public int? DeviceId { get; set; }
        public int? ZoneId { get; set; }
    }
}
