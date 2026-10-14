using System;
using __SARV.Common.Access;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Player")]
    [SVCategory(SVConstantCategory.Property.GAME_OBJECT)]
    [SVDescription("Player GameObject")]
    [Serializable]
    public class SVGameObjectPropertyPlayer : SVPropertyComponent<GameObject>
    {
        public override string ToString()
        {
            return "Player";
        }

        public override GameObject GetValue(SVArgument argument)
        {
            return SVAccessPlayer.GameObject;
        }
    }
}