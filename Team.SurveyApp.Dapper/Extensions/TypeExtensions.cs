using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Team.SurveyApp.Dapper.Extensions
{
    internal static class TypeExtensions
    {
        private static IEnumerable<Type> _acceptedNonPrimitiveTypes = new Type[]
        {
            typeof(DateTime),
            typeof(string)
        };

        public static IEnumerable<PropertyInfo> StorableProperties(this Type type) => type.GetProperties()
                .Where(p => p.PropertyType.IsPrimitive || p.PropertyType.IsEnum || _acceptedNonPrimitiveTypes.Any(a => a == p.PropertyType));

    }
}
