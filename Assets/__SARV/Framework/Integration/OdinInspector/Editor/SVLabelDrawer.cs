using __SARV.Common.Extension;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace __SARV.Framework.Integration.OdinInspector.Editor
{
    [DrawerPriority(DrawerPriorityLevel.SuperPriority)]
    public sealed class SVLabelDrawer : OdinAttributeDrawer<SVLabelAttribute, string>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var subtitleProperty = Property.Parent;
            CallNextDrawer(new GUIContent(subtitleProperty.Name.ToPascalCase()));
        }
    }
}