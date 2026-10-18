using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("GameObjectPosition")]
    [SVCategory(SVConstantCategory.Property.VECTOR3)]
    [SVDescription("Returns the world position of a referenced GameObject as a Vector3")]
    [Serializable]
    public class SVVector3PropertyGameObjectPosition : SVPropertyComponent<Vector3>
    {
        [SerializeField] [HideLabel] private GameObject value;
        
        public override string ToString()
        {
            return GetPosition().ToString();
        }

        public override Vector3 GetValue(SVArgument argument)
        {
            return GetPosition();
        }

        private Vector3 GetPosition()
        {
            return value != null ? value.transform.position : Vector3.zero;
        }
    }
}