namespace ManagerServer.Database.MongoEntity
{
    public class RainDetectionEntity
    {
        public int Id { get; set; }
        public DateTime ValueDateStart { get; set; } = DateTime.Now;
        public DateTime ValueDateEnd { get; set; }

    }
}
