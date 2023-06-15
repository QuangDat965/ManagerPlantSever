namespace ManagerServer.Model.StatisticalDataResponse
{
    public class StatisticalResponseModel
    {
        public IEnumerable<StatisticalDataResponseModel>? Temperatures { get; set; }
        public IEnumerable<StatisticalDataResponseModel>? Humidities { get; set; }
        public IEnumerable<StatisticalDataResponseModel>? Rain { get; set; }
    }
}
