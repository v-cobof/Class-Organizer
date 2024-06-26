using Microsoft.AspNetCore.Hosting;

namespace ClassOrganizer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            app.UseCors("AllowAnyOrigin");
            startup.Configure(app);

            app.Run();
        }
    }
}
