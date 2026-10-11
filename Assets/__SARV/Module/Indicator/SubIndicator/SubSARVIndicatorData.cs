using __SARV.Core.Component;
using __SARV.Framework.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Indicator.SubIndicator
{
    public abstract class SubSARVIndicatorData : SubSARVIndicatorReference
    {
        [FoldoutGroup("Data")] [Title("FocusUIPosition")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SVPropertyComponent<Vector3> focusUIPosition = new SVVector3Property();

        [FoldoutGroup("Data")] [Title("DistanceUIPosition")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SVPropertyComponent<Vector3> distanceUIPosition = new SVVector3Property();

        [FoldoutGroup("Data")] [Title("RotationSpeed")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SVPropertyComponent<float> rotationSpeed = new SVFloatProperty();
    }
}