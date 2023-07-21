using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace System
{

    public class TopicEntity
    {
        public string? Id { get; set; }
        public string? Topic { get; set; }
        public string? Message { get; set; }

        public DateTime? Time { get; set; }

        public TopicEntity()
        {
            Time = DateTime.UtcNow;
            Id = ObjectId.GenerateNewId().ToString();
        }
    }

    public class TPC : Controller
    {
        public TopicEntity Context { get; set; }
        public virtual void Process()
        {

        }
    }
    public class TopicProcessing
    {
        static Dictionary<string, TPC>? _map;
        static void Add(TPC controller)
        {
            _map.Add(controller.GetType().Name.ToLower(), controller);
        }
        public static TPC Find(string name)
        {
            if (_map == null)
            {
                _map = new Dictionary<string, TPC>();
                Add(new Temperature());
            }

            return _map[name];
        }
    }

    public class Temperature : TPC
    {

    }

    public class Humidity : TPC
    {
        public override void Process()
        {
            base.Process();
        }
    }
}
