namespace ManagerServer.Model.Device
{
    public class DeviceActionUpdateModel
    {
        public string id { get; set; }
        public string? nameDevice { get; set; }
        public string? descriptionDevice { get; set; }
        public bool isProblem { get; set; } = false;
        public bool isAction { get; set; } = true;
        public string? image { get; set; }
        public int zoneId { get; set; }
    }
}
