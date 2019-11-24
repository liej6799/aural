using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using aural_server_api.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace aural_server_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            builder.DataSource = Configuration.GetSection("ConnectionStrings").GetSection("dbServer").Value;
            builder.UserID = Configuration.GetSection("ConnectionStrings").GetSection("dbUsername").Value;
            builder.Password = Configuration.GetSection("ConnectionStrings").GetSection("dbPassword").Value;
            builder.InitialCatalog = Configuration.GetSection("ConnectionStrings").GetSection("dbDatabase").Value;

            services.AddDbContext<WeatherDatabaseContext>(options => options.UseSqlServer(builder.ConnectionString));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
