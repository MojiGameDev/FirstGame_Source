using __SARV.Common.Extension;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace __SARV.Framework.Integration.OdinInspector.Editor
{
    [DrawerPriority(DrawerPriorityLevel.SuperPriority)]
    public sealed class SVLabelAttributeDrawer : OdinAttributeDrawer<SVLabelAttribute>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var inspectorProperty = Property.Parent;
            CallNextDrawer(new GUIContent(inspectorProperty?.Name.ToPascalCase()));
        }
    }
}