namespace ManagerServer.Model.StatisticalDataResponse
{
    public class StatisticalResponseModel
    {
        public IEnumerable<StatisticalDataResponseModel> Temperatures { get; set; } = new List<StatisticalDataResponseModel> ();
        public IEnumerable<StatisticalDataResponseModel> Humidities { get; set; } = new List<StatisticalDataResponseModel> ();
        public IEnumerable<StatisticalDataResponseModel> Rain { get; set; } = new List<StatisticalDataResponseModel> ();
    }
}
