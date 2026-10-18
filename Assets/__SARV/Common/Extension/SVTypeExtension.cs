using System;
using System.Reflection;
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
        
        public static bool IsNullProperty(this Type type)
        {
            while (type != null)
            {
                if (type.IsGenericType &&
                    type.GetGenericTypeDefinition() ==
                    typeof(Framework.Kernal.Property.SVNullProperty<>))
                {
                    return true;
                }

                type = type.BaseType;
            }

            return false;
        }
        
        public static FieldInfo GetFieldInHierarchy(this Type type, string fieldName)
        {
            while (type != null)
            {
                var field = type.GetField(
                    fieldName,
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.DeclaredOnly);

                if (field != null)
                    return field;

                type = type.BaseType;
            }

            return null;
        }
    }
}