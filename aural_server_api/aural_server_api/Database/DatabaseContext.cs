using aural_library.Model.Database.Weather;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace aural_server_api.Database
{
    public class WeatherDatabaseContext : DbContext
    {
        public WeatherDatabaseContext(DbContextOptions<WeatherDatabaseContext> options)
          : base(options)
        { }

        public DbSet<CityModel> CityModels { get; set; }
    }
}
