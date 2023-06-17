using ManagerServer.StartUp;

internal class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args)
            //.AddServicesContext ()
            .AddMySql()
            .AddServicesBase ()
            .AddServicesIdentity ()
            .AddBackgroundServices ()
            ;
        var app = builder.Build ();
        app.UsesService ();
        app.Run ();


    }
}