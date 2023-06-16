using System.Text;
using uPLibrary.Networking.M2Mqtt;

internal class Program
{
    private static void Main(string[] args)
    {
        //MqttClient client = new MqttClient ("broker.emqx.io");
        //var a = Guid.NewGuid ().ToString ();

        //client.Connect (a);
        //client.MqttMsgPublishReceived += (s, e) =>
        //{
        //    Console.WriteLine (e.Topic.ToString () + ": " + Encoding.UTF8.GetString (e.Message));
        //};
        //client.Subscribe (new string[] { Constant.SystemUrl + "/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

        //var configuration = new ConfigurationBuilder ()
        //.SetBasePath (AppDomain.CurrentDomain.BaseDirectory) // Specify the base path where the appsettings.json file is located
        //.AddJsonFile ("appsettings.json") // Specify the name of the appsettings.json file
        //.Build ();
        //var section = configuration.GetSection ("ConnectionStrings");
        //var value = section.GetValue<string> ("DefaultConnection");
        //Console.WriteLine (value);

        //MqttClient client;
        //client = new MqttClient ("broker.emqx.io");
        //client.MqttMsgPublishReceived += (s, e) =>
        //{
        //    Console.WriteLine (e.Topic);
        //    Console.WriteLine (Encoding.UTF8.GetString (e.Message));

        //};
        //client.Connect ("ghdwbtuwy23123123215553");

        //client.Subscribe (new string[] { "25052001" }, new byte[] { 0 });
        ////Console.ReadKey ();
        //while ( true )
        //{
        //    client.Publish ("25052001", Encoding.UTF8.GetBytes ("Hi i am Tempature 56 abc"));
        //    Thread.Sleep (5000);
        //}



        MqttClient client;
        client = new MqttClient ("broker.emqx.io");
        client.MqttMsgPublishReceived += (s, e) =>
        {
            Console.WriteLine (e.Topic);
            Console.WriteLine (Encoding.UTF8.GetString (e.Message));
        };
        client.Connect ("ghdwbghf222tuwy23123123213");

        client.Subscribe (new string[] { "d6rjcudf7yfrokfyd6w84or994kffef/#" }, new byte[] { 0 });
        client.Publish ("d6rjcudf7yfrokfyd6w84or994kffef" + "/thisisdeviceid1" + "/W" + "/L" + "/IsOnFan", Encoding.UTF8.GetBytes ("1"));
        client.Publish ("d6rjcudf7yfrokfyd6w84or994kffef" + "/thisisdeviceid1" + "/W" + "/L" + "/IsOnWater", Encoding.UTF8.GetBytes ("0"));
        //client.Publish ("d6rjcudf7yfrokfyd6w84or994kffef" + "/thisisdeviceid1" + "/W" + "/L" + "/IsOnFan", Encoding.UTF8.GetBytes ("1"));




    }
    class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}