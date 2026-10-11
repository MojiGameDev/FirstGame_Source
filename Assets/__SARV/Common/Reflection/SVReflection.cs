using System;
using System.Collections.Generic;
using System.Linq;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Extension;
using __SARV.Variable.Base;
using Unity.VisualScripting;

namespace __SARV.Core.Reflection
{
    public static class SVReflection
    {
        public static List<string> GetAllSignalComponentPaths()
        {
            return GetAllSARVTypes<SVSignalComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllInstructionComponentPaths()
        {
            return GetAllSARVTypes<SVInstructionComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllBranchComponentPaths()
        {
            return GetAllSARVTypes<SVBranchComponent>()
                .Select(GetMenuPath)
                .ToList();
        }

        public static List<string> GetAllBehaviorComponentPaths<TType>() where TType : SVBehaviorComponent
        {
            return GetAllSARVTypes<TType>()
                .Select(d => d.GetTitle())
                .ToList();
        }

        public static List<string> GetVariableValueTitles()
        {
            return GetAllSARVTypes<SVVariableValue>()
                .Select(d => d.GetTitle())
                .ToList();
        }

        public static List<string> GetPropertyTitlesByType<TType>()
        {
            return GetAllSARVTypes<SVPropertyComponent<TType>>()
                .Select(d => d.GetTitle())
                .ToList();
        }

        public static Type GetSignalByPath(string path)
        {
            return GetAllSARVTypes<SVSignalComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        public static Type GetBehaviorComponentByPath<TType>(string path) where TType : SVBehaviorComponent
        {
            return GetAllSARVTypes<TType>()
                .FirstOrDefault(t => t.GetTitle() == path);
        }

        public static Type GetInstructionByPath(string path)
        {
            return GetAllSARVTypes<SVInstructionComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        public static Type GetBranchByPath(string path)
        {
            return GetAllSARVTypes<SVBranchComponent>()
                .FirstOrDefault(t => GetMenuPath(t) == path);
        }

        public static Type GetPropertyTypeByTitle<TType>(string title)
        {
            return GetAllSARVTypes<SVPropertyComponent<TType>>()
                .FirstOrDefault(d => d.GetTitle() == title);
        }

        public static Type GetVariableValueByTitle(string title)
        {
            return GetAllSARVTypes<SVVariableValue>()
                .FirstOrDefault(d => d.GetTitle() == title);
        }

        private static string GetMenuPath(Type componentType)
        {
            var title = componentType.GetTitle();
            var category = componentType.GetCategory();
            return $"{category}/{title}";
        }

        private static List<Type> GetAllSARVTypes<TInheritFrom>()
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