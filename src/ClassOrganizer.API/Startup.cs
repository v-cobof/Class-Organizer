using ClassOrganizer.API.Configs;
using Microsoft.AspNetCore.Builder;

namespace ClassOrganizer.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            /*services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Manager API", Version = "v1" });
                c.EnableAnnotations();
            });*/

            services.AddDatabase(Configuration);
            services.AddDependencyInjection(Configuration);
        }

        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
