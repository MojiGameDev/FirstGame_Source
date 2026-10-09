using System;
using System.Collections.Generic;
using System.Linq;
using __SARV.Core.Attributes;
using __SARV.Core.Base;
using __SARV.Core.Component;
using __SARV.Core.Component.Base;
using __SARV.Core.Extension;
using __SARV.Variable.Base;
using Unity.VisualScripting;

namespace __SARV.Core.Reflection
{
    public static class SVReflection
    {
        public static List<string> GetAllSignalComponentPaths()
        {
            return GetAllPropertyTypes<SVSignalComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllInstructionComponentPaths()
        {
            return GetAllPropertyTypes<SVInstructionComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllBranchComponentPaths()
        {
            return GetAllPropertyTypes<SVBranchComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllBehaviorComponentPaths()
        {
            return GetAllPropertyTypes<SVBehaviorComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetVariableValueTitles()
        {
            return GetAllPropertyTypes<SVVariableValue>()
                .Select(d => d.GetTitle())
                .ToList(); }

        public static List<string> GetPropertyTitlesByType<TType>()
        {
            return GetAllPropertyTypes<SVPropertyComponent<TType>>()
                .Select(d => d.GetTitle())
                .ToList();
        }

        public static Type GetSignalByPath(string path)
        {
            return GetAllPropertyTypes<SVSignalComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        public static Type GetBehaviorByPath(string path)
        {
            return GetAllPropertyTypes<SVBehaviorComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        public static Type GetInstructionByPath(string path)
        {
            return GetAllPropertyTypes<SVInstructionComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        public static Type GetBranchByPath(string path)
        {
            return GetAllPropertyTypes<SVBranchComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        public static Type GetPropertyTypeByTitle<TType>(string title)
        {
            return GetAllPropertyTypes<SVPropertyComponent<TType>>()
                .FirstOrDefault(d => d.GetTitle() == title);
        }

        public static Type GetVariableValueByTitle(string title)
        {
            return GetAllPropertyTypes<SVVariableValue>()
                .FirstOrDefault(d => d.GetTitle() == title);
        }

        private static string GetMenuPath(Type componentType)
        {
            var title = componentType.GetTitle();
            var category = componentType.GetCategory();
            return $"{category}/{title}";
        }

        private static List<Type> GetAllPropertyTypes<TInheritFrom>()
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
    }
}