using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Tag")]
    [SVCategory(SVConstantCategory.Property.STRING)]
    [SVDescription("Allows selecting a tag from the list of available Unity tags")]
    [Serializable]
    public class SVStringPropertyTag : SVPropertyComponent<string>
    {
        [SerializeField] [HideLabel] [ValueDropdown("@UnityEditorInternal.InternalEditorUtility.tags")]
        private string value;

        public override string ToString()
        {
            return value;
        }

        public override string GetValue(SVArgument argument)
        {
            return value;
        }
    }
}