namespace ManagerServer.Model.StatisticalDataResponse
{
    public class StatisticalDataResponseModel
    {
        public int Id { get; set; }
        public int? DeviceMeasureId { get; set; }
        public DateTime ValueDate { get; set; } // thoi gian tao => cuối mỗi giờ
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double AvgValue { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double TotalValue { get; set; }
        public DateTime DateRetrive { get; set; }
    }
}
