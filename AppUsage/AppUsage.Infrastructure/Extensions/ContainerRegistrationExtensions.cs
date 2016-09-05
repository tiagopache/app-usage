using Microsoft.Practices.Unity;
using System;

namespace AppUsage.Infrastructure.Extensions
{
    public static class ContainerRegistrationExtensions
    {
        public static string GetMappingAsString(this ContainerRegistration registration)
        {
            string regName, regType, mapTo, lifeTime;

            var r = registration.RegisteredType;
            regType = r.Name + getGenericArgumentsList(r);

            var m = registration.MappedToType;
            mapTo = m.Name + getGenericArgumentsList(m);

            regName = registration.Name ?? "[default]";

            lifeTime = registration.LifetimeManagerType.Name;

            if (mapTo != regType)
                mapTo = $" -> {mapTo}";
            else
                mapTo = string.Empty;

            lifeTime = lifeTime.Substring(0, lifeTime.Length - "LifeTimeManager".Length);

            return $"+ {regType}{mapTo} '{regName}' {lifeTime}";
        }

        private static string getGenericArgumentsList(Type type)
        {
            if (type.GetGenericArguments().Length == 0)
                return string.Empty;

            var argList = string.Empty;

            var first = true;

            foreach (Type t in type.GetGenericArguments())
            {
                argList += first ? t.Name : $", {t.Name}";

                first = false;

                if (t.GetGenericArguments().Length > 0)
                    argList += getGenericArgumentsList(t);
            }

            return $"<{argList}>";
        }
    }
}
