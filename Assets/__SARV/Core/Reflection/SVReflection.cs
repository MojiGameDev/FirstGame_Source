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
                    type != typeof(TInheritFrom) &&
                    typeof(TInheritFrom).IsAssignableFrom(type) &&
                    !type.HasAttribute<SVIgnoreAttribute>())
                .Select(type => (TInheritFrom)Activator.CreateInstance(type))
                .ToList();
        }

        public static List<string> GetAllSignalComponents()
        {
            return GetAllTypes<SVSignalComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllInstructionComponents()
        {
            return GetAllTypes<SVInstructionComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllBranchComponents()
        {
            return GetAllTypes<SVBranchComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static SVSignalComponent GetSignalByPath(string path)
        {
            return GetAllTypes<SVSignalComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        public static SVInstructionComponent GetInstructionByPath(string path)
        {
            return GetAllTypes<SVInstructionComponent>()
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