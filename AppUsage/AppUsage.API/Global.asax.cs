using AppUsage.Infrastructure.Data.Contexts;
using AppUsage.Infrastructure.DependencyInjection;
using System.Web.Http;

namespace AppUsage.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            InjectFactory.Resolve<IDbContext>().Initialize();
        }
    }
}
