using __SARV.Framework.Attributes;
using __SARV.Framework.Component;
using __SARV.Framework.Logic;
using Sirenix.Utilities;

namespace __SARV.Framework.Extension
{
    public static class SVFrameworkExtension
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
    }
}