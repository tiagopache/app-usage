using AppUsage.Infrastructure.Extensions;
using Microsoft.Practices.Unity;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AppUsage.Infrastructure.DependencyInjection
{
    public class UnityHelper
    {
        [Conditional("DEBUG")]
        public static void GetRegistrations(IUnityContainer container)
        {
            var builder = new StringBuilder();

            Debug.WriteLine($"Container has {container.Registrations.Count()} registrations: ");

            foreach (ContainerRegistration item in container.Registrations)
            {
                builder.AppendLine(item.GetMappingAsString());
            }

            Debug.WriteLine(builder.ToString());
        }
    }
}
