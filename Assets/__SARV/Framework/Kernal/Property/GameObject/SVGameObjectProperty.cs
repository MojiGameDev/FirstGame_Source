using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Constant;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
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
            return GetValue(default).name;
        }
    }
}