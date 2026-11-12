using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.Actor.Access;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("PlayerPosition")]
    [SVCategory(SVConstantCategory.Property.VECTOR3)]
    [SVDescription("Returns the current world position of the Player")]
    [Serializable]
    public class SVVector3PropertyPlayerPosition : SVPropertyComponent<Vector3>
    {
        public override string ToString()
        {
            return "PlayerPosition";
        }

        public override Vector3 GetValue(SVArgument argument)
        {
            return SVAccessPlayer.Instance.Position;
        }
    }
}