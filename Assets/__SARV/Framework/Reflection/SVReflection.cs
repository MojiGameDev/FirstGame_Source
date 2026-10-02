using System;
using System.Collections.Generic;
using System.Linq;
using __SARV.Framework.Attributes;
using __SARV.Framework.Component;
using __SARV.Framework.Extension;
using __SARV.Framework.Logic;
using Unity.VisualScripting;
using UnityEngine;

namespace __SARV.Framework.Reflection
{
    public static class SVReflection
    {
        public static List<TInheritFrom> FindAllTypes<TInheritFrom>()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type =>
                    type.IsClass &&
                    !type.IsAbstract &&
                    typeof(TInheritFrom).IsAssignableFrom(type))
                .Select(type => (TInheritFrom)Activator.CreateInstance(type))
                .ToList();
        }

        // public static List<string> GetAllTitles()
        // {
        //     return FindAllTypes<MDVariable>()
        //         .Select(t => t.GetCustomAttribute<MDTitleAttribute>().Title)
        //         .ToList();
        // }
        //
        // public static List<string> GetAllActions()
        // {
        //     return FindAllTypes<MDAction>()
        //         .Select(t => GetActionMenuPath(t.Name))
        //         .ToList();
        // }
        //
        // public static List<string> GetAllConditions()
        // {
        //     return FindAllTypes<MDCondition>()
        //         .Select(t => GetConditionMenuPath(t.Name))
        //         .ToList();
        // }
        //
        public static List<string> GetAllTriggerComponents()
        {
            return FindAllTypes<SVTriggerComponent>()
                .Select(GetMenuPath)
                .ToList();
        }
        //
        // public static List<string> GetAllPropertyTypes<TType>()
        // {
        //     return FindAllTypes<MDProperty<TType>>()
        //         .Select(t => GetTriggerMenuPath(t.Name))
        //         .ToList();
        // }
        //
        // public static Type FindVariableByTitle(string title)
        // {
        //     return FindAllTypes<MDVariable>()
        //         .FirstOrDefault(t => t.GetCustomAttribute<MDTitleAttribute>().Title == title);
        // }
        //
        // public static Type FindActionByPath(string path)
        // {
        //     return FindAllTypes<MDAction>()
        //         .FirstOrDefault(t => GetActionMenuPath(t.Name) == path);
        // }
        //
        // public static Type FindConditionByPath(string path)
        // {
        //     return FindAllTypes<MDCondition>()
        //         .FirstOrDefault(t => GetConditionMenuPath(t.Name) == path);
        // }
        //
        // public static Type FindTriggerByPath(string path)
        // {
        //     return FindAllTypes<MDTrigger>()
        //         .FirstOrDefault(t => GetTriggerMenuPath(t.Name) == path);
        // }
        //
        // public static Type FindTypPropertyTypeByPath<TType>(string path)
        // {
        //     return FindAllTypes<MDProperty<TType>>()
        //         .FirstOrDefault(t => GetTriggerMenuPath(t.Name) == path);
        // }
        //
        // public static bool ExistVariableByTitle(string title)
        // {
        //     return FindAllTypes<MDVariable>()
        //         .Any(t => t.GetCustomAttribute<MDTitleAttribute>().Title == title);
        // }

        private static string GetActionMenuPath(string value)
        {
            return GetMenuPath(value, "Action");
        }

        private static string GetConditionMenuPath(string value)
        {
            return GetMenuPath(value, "Condition");
        }

        private static string GetTriggerMenuPath(string value)
        {
            return GetMenuPath(value, "Trigger");
        }

        private static string GetMenuPath(SVComponent component)
        {
            var title = component.GetTitle();
            var category = component.GetCategory();
            return $"{category}/{title}";
        }

        private static string GetPropertyMenuPath(string value)
        {
            return GetMenuPath(value, "Property");
        }

        private static string GetMenuPath(string value, string separator)
        {
            if (value.StartsWith("SV"))
            {
                value = value[2..];
            }

            var index = value.IndexOf(separator, StringComparison.Ordinal);
            if (index < 0)
            {
                return value;
            }

            var category = value[..index];
            var action = value[(index + separator.Length)..];

            return $"{category}/{action}";
        }
    }
}