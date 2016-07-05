﻿using System;
using System.Linq;
using System.Reflection;

namespace Photosphere.Console.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static bool HasAttribute<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute : Attribute
        {
            return propertyInfo.GetCustomAttributes<TAttribute>().Any();
        }

        public static TAttribute GetFirstAttribute<TAttribute>(this PropertyInfo type)
            where TAttribute : Attribute
        {
            return type.GetCustomAttributes<TAttribute>().First();
        }
    }
}