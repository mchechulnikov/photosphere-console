using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Photosphere.Console.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<PropertyInfo> GetPropertiesWith<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            return type.GetPublicProperties().Where(p => p.HasAttribute<TAttribute>());
        }

        public static IEnumerable<TAttribute> GetTypePropertiesAttributes<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            return type.GetPublicProperties().SelectMany(p => p.GetCustomAttributes<TAttribute>());
        }

        private static IEnumerable<PropertyInfo> GetPublicProperties(this Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}