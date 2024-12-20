using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DUK2AC_HFT_2022231.Logic;
using DUK2AC_HFT_2022231.Repositroy;
using DUK2AC_HFT_2022231.Models;
using System.Text.Json.Serialization;

namespace DUK2AC_HFT_2022231.Endpoint2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<GameShopDbContext>();

            services.AddTransient<IRepo<Game>, GameRepo>();
            services.AddTransient<IRepo<Developer>, DevRepo>();
            services.AddTransient<IRepo<Achievement>, AchievementRepo>();
            

            services.AddTransient<IGameLogic, GameLogic>();
            services.AddTransient<IDeveloperLogic, DeveloperLogic>();
            services.AddTransient<IAchievementLogic, AchievementLogic>();
            

            services.AddControllers().AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DUK2AC_HFT_2022231.Endpoint2", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DUK2AC_HFT_2022231.Endpoint2 v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
