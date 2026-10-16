using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Layer")]
    [SVCategory(SVConstantCategory.Property.STRING)]
    [SVDescription("Allows selecting a Unity layer from the list of available layers")]
    [Serializable]
    public class SVStringPropertyLayer : SVPropertyComponent<string>
    {
        [SerializeField] [HideLabel] [ValueDropdown("@UnityEditorInternal.InternalEditorUtility.layers")]
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