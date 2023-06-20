using app.Context;
using app.Models.Entities;
using app.Repositories;
using app.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace app
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
            var dbProvider = Configuration.GetConnectionString("Provider");
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EFDbContext>(optionBuilder =>
            {
                switch (dbProvider)
                {
                    case "MSSQL":
                        optionBuilder.UseSqlServer(connection);
                        break;
                    default:
                        optionBuilder.UseMySql(connection);
                        break;
                }
            });
            
            // Add client services.
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IMessageService, MessageService>();
            // Add framework services.
            services.AddAutoMapper();
            services.AddMvc();	
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // опциональная сборка via webpack
                if (Configuration.GetSection("IsNativeWebpackBuilder").Value.Equals(bool.TrueString))                    
                    app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                    {
                        HotModuleReplacement = false
                    });
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

			app.UseMvc();
        }
    }
}
