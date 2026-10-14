using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Manual")]
    [SVCategory(SVConstantCategory.Property.GAME_OBJECT)]
    [SVDescription("Enter a game object")]
    [Serializable]
    public class SVGameObjectPropertyManual : SVPropertyComponent<GameObject>
    {
        [SerializeField] [HideLabel]
        private GameObject value;
        
        public override string ToString()
        {
            return $"Manual({value})";
        }

        public override GameObject GetValue(SVArgument argument)
        {
            return value;
        }
    }
}