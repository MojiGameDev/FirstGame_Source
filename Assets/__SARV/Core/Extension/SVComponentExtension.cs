using __SARV.Core.Attributes;
using __SARV.Framework.Component.Base;
using Sirenix.Utilities;

namespace __SARV.Core.Extension
{
    public static class SVComponentExtension
    {
        public static string GetTitle(this SVComponent component)
        {
            if (component == null)
            {
                return string.Empty;
            }

            var attribute = component.GetType()
                .GetCustomAttribute<SVTitleAttribute>();

            return attribute?.Value ?? component.GetType().Name;
        }

        public static string GetCategory(this SVComponent component)
        {
            if (component == null)
            {
                return string.Empty;
            }

            var attribute = component.GetType()
                .GetCustomAttribute<SVCategoryAttribute>();

            return attribute?.Value ?? component.GetType().Name;
        }

        public static string GetDescription(this SVComponent component)
        {
            if (component == null)
            {
                return string.Empty;
            }

            var attribute = component.GetType()
                .GetCustomAttribute<SVDescriptionAttribute>();

            return attribute?.Value ?? component.GetType().Name;
        }
    }
}