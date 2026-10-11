using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component.Base;
using Sirenix.Utilities;

namespace __SARV.Core.Extension
{
    public static class SVTypeExtension
    {
        public static string GetTitle(this Type type)
        {
            if (type == null)
            {
                return string.Empty;
            }

            var attribute = type.GetCustomAttribute<SVTitleAttribute>();
            return attribute?.Value ?? type.Name;
        }

        public static string GetCategory(this Type type)
        {
            if (type == null)
            {
                return string.Empty;
            }

            var attribute = type.GetCustomAttribute<SVCategoryAttribute>();
            return attribute?.Value ?? type.Name;
        }

        public static string GetDescription(this Type type)
        {
            if (type == null)
            {
                return string.Empty;
            }

            var attribute = type.GetCustomAttribute<SVDescriptionAttribute>();
            return attribute?.Value ?? type.Name;
        }
    }
}