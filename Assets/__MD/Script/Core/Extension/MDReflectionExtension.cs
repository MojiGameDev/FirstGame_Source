using System.Reflection;
using UnityEngine;

namespace __MD.Script.Core.Extension
{
    public static class MDReflectionExtension
    {
        public static T CloneScriptableObject<T>(this T source) where T : ScriptableObject
        {
            var clone = ScriptableObject.CreateInstance(source.GetType());

            var type = source.GetType();

            while (type != null && type != typeof(UnityEngine.Object))
            {
                var fields = type.GetFields(
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.DeclaredOnly);

                foreach (var field in fields)
                {
                    if (field.IsStatic || field.IsLiteral)
                    {
                        continue;
                    }

                    field.SetValue(clone, field.GetValue(source));
                }

                type = type.BaseType;
            }

            return (T)clone;
        }

        public static T GetPropertyValue<T>(this object target, string propertyName)
        {
            var propertyInfo = target.GetType().GetProperty(propertyName,
                BindingFlags.NonPublic | BindingFlags.Instance);

            if (propertyInfo == null && target.GetType().BaseType != null)
            {
                propertyInfo = target.GetType().BaseType?.GetProperty(propertyName,
                    BindingFlags.NonPublic | BindingFlags.Instance);
            }

            return (T)propertyInfo?.GetValue(target);
        }

        public static T GetFieldValue<T>(this object obj, string fieldName)
        {
            var fieldInfo = obj.GetType().GetField(fieldName,
                BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo == null && obj.GetType().BaseType != null)
            {
                fieldInfo = obj.GetType().BaseType?.GetField(fieldName,
                    BindingFlags.NonPublic | BindingFlags.Instance);
            }

            return (T)fieldInfo?.GetValue(obj);
        }
    }
}