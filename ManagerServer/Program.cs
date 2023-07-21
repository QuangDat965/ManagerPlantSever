using ManagerServer.StartUp;

internal class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args)
            //.AddServicesContext()
            .AddMySql()
            .AddServicesBase()
            .AddServicesIdentity()
            .AddBackgroundServices()
            .AddConfiguationMongodb();
        var app = builder.Build();
        app.UsesService();
        app.Run();


    }
}