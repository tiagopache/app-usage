using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AppUsage.Application.Contract.Contracts;
using AppUsage.Application.Service;
using Swashbuckle.Swagger.Model;
using Microsoft.Extensions.PlatformAbstractions;
using AppUsage.Business.Contract;
using AppUsage.Business.Service;
using AppUsage.Model.Contexts;
using Microsoft.Extensions.Configuration;
using AppUsage.Infrastructure.Data.Contexts;
using AppUsage.Infrastructure.Data.Repositories;
using AppUsage.Infrastructure.Data;

namespace AppUsage.API
{
    public class Startup
    {
        string _envRootPath = string.Empty;
        string _envName = string.Empty;

        public Startup(IHostingEnvironment env)
        {
            _envRootPath = env.ContentRootPath;
            _envName = env.EnvironmentName;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            var builder = new ConfigurationBuilder()
                            .SetBasePath(_envRootPath)
                            .AddJsonFile($"appsettings.{_envName}.json");

            var connStrConfig = builder.Build();

            var connStr = connStrConfig.GetConnectionString("AppUsageDbContext");

            //services.AddDbContext<AppUsageDbContext>();

            services.AddScoped<IDbContext, AppUsageDbContext>((sp) =>
            {
                return new AppUsageDbContext(connStr);
            });

            services.AddScoped<IPartnerApplicationService, PartnerApplicationService>();
            services.AddScoped<IPartnerBusinessService, PartnerBusinessService>();

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddMvc();

            services.AddSwaggerGen();

            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info()
                {
                    Version = "v1",
                    Title = "App Usage API",
                    Description = "API for AppUsage Application",
                    TermsOfService = "None",
                    Contact = new Contact { Email = "", Name = "Tiago Pache", Url = "http://twitter.com/tiagopache" },
                    License = new License { Name = "GPL3", Url = "https://www.gnu.org/licenses/gpl.html" }
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                options.IncludeXmlComments($"{basePath}\\AppUsage.API.xml");
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IDbContext context)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();

            app.UseMvcWithDefaultRoute();

            app.UseSwagger();

            app.UseSwaggerUi();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            context.Initialize();
        }
    }
}
