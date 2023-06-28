using ManagerServer.Common.Constant;
using ManagerServer.Common.Enum;
using ManagerServer.Database;
using ManagerServer.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MyProject.Services
{
    public class ListeningService : BackgroundService
    {
        private readonly MqttClient _client;
        private readonly string _clientId;
        private readonly IConfiguration configuration;
        

        public ListeningService(IConfiguration configuration)
        {
            _client = new MqttClient(Constant.BrokerURL);
            _clientId = Guid.NewGuid().ToString();
            this.configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _client.MqttMsgPublishReceived += async (s, e) =>
            {
                await SaveToDb (e);
            };
            while ( !stoppingToken.IsCancellationRequested )
            {

                try
                {
                    if ( !_client.IsConnected )
                    {
                        _client.Connect (_clientId);
                        Console.WriteLine ("MQTT connected");
                        _client.Subscribe (new string[] { Constant.SystemUrl + "/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                    }

                }
                catch ( Exception e )
                {
                    Console.WriteLine ("fail listening main" + e.Message);
                }
                await Task.Delay (2000, stoppingToken);
            }
        }

        private async Task<bool> SaveToDb(MqttMsgPublishEventArgs e)
        {
          var builder = new DbContextOptionsBuilder<ManagerDbContext>().UseMySql(configuration["ConnectionStrings:MySqlConnection"], new MySqlServerVersion(new Version(5, 7, 0)));
            try
            {
                var arr = e.Topic.Split ('/');
                using ( var context = new ManagerDbContext (builder.Options) )
                {
                    try
                    {
                        bool deviceSensor = false;
                        if (arr[2] == "R")
                        {
                            deviceSensor = true;
                        }

                        if (deviceSensor)
                        {
                            var device = await context.MeasuringDeviceEntities.FirstOrDefaultAsync(p => p.Id == arr[1]);
                            if (device == null)
                            {
                                var devicetemp = new MeasuringDeviceEntity()
                                {
                                    DateCreate = DateTime.Now,
                                    Name = arr[3],
                                    Id = arr[1],
                                    DeviceType = arr[3] == "temperature" ? DeviceType.TemperatureMeasurementDevice :
                                                 arr[3] == "humidity" ? DeviceType.HumidityMeasuringDevice :
                                                 arr[3] == "raindetection" ? DeviceType.RainDetection :
                                                 DeviceType.Unknown,

                                };
                                context.Add(devicetemp);
                                context.SaveChanges();
                            }
                        }
                        else
                        {
                            var device = await context.DeviceActionEntities.FirstOrDefaultAsync(p => p.Id == arr[1]);
                            if (device == null)
                            {
                                var devicetemp = new DeviceActionEntity()
                                {
                                    DateCreate = DateTime.Now,
                                    Name = arr[3],
                                    Id = arr[1],
                                    DeviceActionType = arr[3] == "IsOnWater" ? DeviceActionType.Spinkklers :
                                                 arr[3] == "IsOnFan" ? DeviceActionType.Fan :
                                                 arr[3] == "IsOnLamp" ? DeviceActionType.Lamp :
                                                 arr[3] == "IsOnCover" ? DeviceActionType.Coverd :
                                                 DeviceActionType.Unknown,

                                };
                                context.Add(devicetemp);
                                context.SaveChanges();
                            }
                        }
                        //var datatemp = new DataDeviceResponseEntity ()
                        //{
                        //    Topic = arr[3],
                        //    Payload = Encoding.UTF8.GetString (e.Message),
                        //    TimeRetrieve = DateTime.Now,
                        //    DataDeviceId = int.Parse (arr[1]),
                        //};
                        //context.Add (datatemp);
                        //context.SaveChanges ();
                    }
                    catch ( Exception ex )
                    {

                    };
                }
                return true;

            }
            catch ( Exception ex )
            {
                Console.WriteLine ("save erro:" + ex.Message);
                throw;
            }
        }
    }
}
