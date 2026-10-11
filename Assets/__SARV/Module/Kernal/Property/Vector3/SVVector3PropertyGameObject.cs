using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("GameObject")]
    [SVCategory(SVConstantCategory.Property.VECTOR3)]
    [SVDescription("Returns the world position of a referenced GameObject as a Vector3")]
    [Serializable]
    public class SVVector3PropertyGameObject : SVPropertyComponent<Vector3>
    {
        [SerializeField] [HideLabel] private GameObject value;

        public override Vector3 Value => value.transform.position;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}