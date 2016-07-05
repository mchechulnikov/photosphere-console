using System;
using System.Collections.Generic;

namespace Photosphere.Console.Extensions
{
    public static class ObjectExtensions
    {
        public static IEnumerable<TAttribute> GetPropertiesAttributes<TAttribute>(this object obj)
            where TAttribute : Attribute
        {
            return obj.GetType().GetTypePropertiesAttributes<TAttribute>();
        }
    }
}