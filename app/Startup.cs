using app.Context;
using app.Services;
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
            string providerDB = Configuration.GetSection("DBProvider").Value;
            if (providerDB.Equals("MySQL"))
            {
                var connection = Configuration.GetConnectionString("MySqlConnection");
                services.AddDbContext<EFDbContext>(options => options.UseMySql(connection));
            }
            // Add client services.
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IMessageService, MessageService>();
            // Add framework services.
            services.AddMvc();			
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

				//добавляем сборку через webpack
				app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
				{
					HotModuleReplacement = true
				});
			}

			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseMvc();
        }
    }
}
