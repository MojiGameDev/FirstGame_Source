using __SARV.Framework.Common.Component;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.State;
using __SARV.Service.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SubSARVIndicatorReference : SARV
    {
        [FoldoutGroup("Reference")] [Title("Target")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SVPropertyComponent<GameObject> target = new SVGameObjectProperty();

        [FoldoutGroup("Reference")] [Title("FocusUIIdentifier")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SARVIdentifier focusUIIdentifier;

        [FoldoutGroup("Reference")] [Title("DistanceUIIdentifier")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SARVIdentifier distanceUIIdentifier;
    }
}