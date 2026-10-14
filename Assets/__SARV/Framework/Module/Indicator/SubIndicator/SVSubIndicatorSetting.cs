using __SARV.Framework.Common.Component;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorSetting : SVSubIndicatorReference
    {
        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(1, 10)]
        protected float rotationSpeed = 4f;
    }
}