using System;
using __SARV.Framework.Common.Attributes;
using Sirenix.Utilities;

namespace __SARV.Common.Extension
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