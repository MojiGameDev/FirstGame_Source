using System;
using __SARV.Core.Attributes;
using __SARV.Core.Base;
using __SARV.Core.Constant;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("GameObject")]
    [SVCategory(SVConstantCategory.Property.GAME_OBJECT)]
    [SVDescription("Includes all properties that are composed of game objects")]
    [SVIgnore]
    [Serializable]
    public class SVGameObjectProperty : SVParentProperty<GameObject>
    {
        public override string ToString()
        {
            return Value.name;
        }
    }
}