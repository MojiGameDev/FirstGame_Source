using __SARV.Framework.Common.Component;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorData : SVSubIndicatorReference
    {
        [FoldoutGroup("Data")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SVPropertyComponent<Vector3> focusUIPosition = new SVVector3Property();

        [FoldoutGroup("Data")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SVPropertyComponent<Vector3> distanceUIPosition = new SVVector3Property();

        [FoldoutGroup("Data")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel] [PropertyRange(1, 10)]
        protected float rotationSpeed = 4f;
    }
}