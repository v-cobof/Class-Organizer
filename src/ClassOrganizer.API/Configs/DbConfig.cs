using ClassOrganizer.Infrastructure.Dados;

namespace ClassOrganizer.API.Configs
{
    public static class DbConfig
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(provider =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                return new DbContext(connectionString);
            });
        }
    }
}
