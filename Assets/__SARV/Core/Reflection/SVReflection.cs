using System;
using System.Collections.Generic;
using System.Linq;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Extension;
using Unity.VisualScripting;

namespace __SARV.Core.Reflection
{
    public static class SVReflection
    {
        public static List<Type> GetAllTypes<TInheritFrom>()
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
                .ToList();
        }

        public static List<string> GetAllSignalComponentPaths()
        {
            return GetAllTypes<SVSignalComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllInstructionComponentPaths()
        {
            return GetAllTypes<SVInstructionComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllBranchComponentPaths()
        {
            return GetAllTypes<SVBranchComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetPropertyTitlesByType<TType>()
        {
            return GetAllTypes<SVPropertyComponent<TType>>()
                .Select(d=>d.GetTitle())
                .ToList();
        }

        public static Type GetSignalByPath(string path)
        {
            return GetAllTypes<SVSignalComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        public static Type GetInstructionByPath(string path)
        {
            return GetAllTypes<SVInstructionComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        public static Type GetBranchByPath(string path)
        {
            return GetAllTypes<SVBranchComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        public static Type GetPropertyTypeByTitle<TType>(string title)
        {
            return GetAllTypes<SVPropertyComponent<TType>>()
                .FirstOrDefault(d => d.GetTitle() == title);
        }

        private static string GetMenuPath(Type componentType)
        {
            var title = componentType.GetTitle();
            var category = componentType.GetCategory();
            return $"{category}/{title}";
        }
    }
}