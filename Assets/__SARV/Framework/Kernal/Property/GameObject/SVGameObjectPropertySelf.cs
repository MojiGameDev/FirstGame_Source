using System;
using __SARV.Common.Access;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Self")]
    [SVCategory(SVConstantCategory.Property.GAME_OBJECT)]
    [SVDescription("Self GameObject")]
    [Serializable]
    public class SVGameObjectPropertySelf : SVPropertyComponent<GameObject>
    {
        public override string ToString()
        {
            return "Self";
        }

        public override GameObject GetValue(SVArgument argument)
        {
            return argument.Self;
        }
    }
}