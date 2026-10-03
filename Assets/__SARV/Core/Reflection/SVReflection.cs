using System;
using System.Collections.Generic;
using System.Linq;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Component.Base;
using __SARV.Core.Extension;
using Unity.VisualScripting;

namespace __SARV.Core.Reflection
{
    public static class SVReflection
    {
        public static List<TInheritFrom> GetAllTypes<TInheritFrom>()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type =>
                    type.IsClass &&
                    !type.IsAbstract &&
                    typeof(TInheritFrom).IsAssignableFrom(type) &&
                    !type.HasAttribute<SVIgnoreAttribute>())
                .Select(type => (TInheritFrom)Activator.CreateInstance(type))
                .ToList();
        }

        public static List<string> GetAllTriggerComponents()
        {
            return GetAllTypes<SVTriggerComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllActionComponents()
        {
            return GetAllTypes<SVActionComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllConditionComponents()
        {
            return GetAllTypes<SVConditionComponent>()
                .Select(GetMenuPath)
                .ToList();
        }
        
        public static SVTriggerComponent GetTriggerByPath(string path)
        {
            return GetAllTypes<SVTriggerComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }
        
        public static SVPropertyComponent<TType> GetPropertyTypeByPath<TType>(string path)
        {
            return GetAllTypes<SVPropertyComponent<TType>>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        private static string GetMenuPath(SVComponent component)
        {
            var title = component.GetTitle();
            var category = component.GetCategory();
            return $"{category}/{title}";
        }
    }
}