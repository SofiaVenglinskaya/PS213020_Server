using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PS213020_Server.AutomapperProfile;
using PS213020_Server.BussinessLogic.AutoMapperProfile;
using PS213020_Server.DataAccess.Core.Interface.Context;
using PS213020_Server.DataAccess.DbContext;

namespace PS213020_Server
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
            services.AddControllers();
            services.AddAutoMapper(typeof(BussinessLogicProfile), typeof(MicroserviceProfile));
            services.AddDbContext<IRubicContext, RubicContext>(o => o.UseSqlite("Data Source=usersdata.db; Foreign Keys=True"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor
                | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthorization();

            using var scope = app.ApplicationServices.CreateScope();

            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            var dbContext = scope.ServiceProvider.GetRequiredService<RubicContext>();
            dbContext.Database.Migrate();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
