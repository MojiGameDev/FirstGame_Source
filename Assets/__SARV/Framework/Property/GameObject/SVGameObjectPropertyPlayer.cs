using System;
using __SARV.Core.Access;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("Player")]
    [SVCategory(SVConstantCategory.Property.GAME_OBJECT)]
    [SVDescription("Player GameObject")]
    [Serializable]
    public class SVGameObjectPropertyPlayer : SVPropertyComponent<GameObject>
    {
        public override GameObject Value => SVAccessPlayer.GameObject;

        public override string ToString()
        {
            return "Player";
        }
    }
}