using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("Manual")]
    [SVCategory(SVConstantCategory.Property.GAME_OBJECT)]
    [SVDescription("Enter a game object")]
    [Serializable]
    public class SVGameObjectPropertyManual : SVPropertyComponent<GameObject>
    {
        [SerializeField] [HideLabel]
        private GameObject value;

        public override GameObject Value => value;

        public override string ToString()
        {
            return $"Manual({Value.name})";
        }
    }
}