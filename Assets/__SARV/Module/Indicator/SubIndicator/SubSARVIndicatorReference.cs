using __SARV.Core.Component;
using __SARV.Framework;
using __SARV.Framework.Property;
using __SARV.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Indicator.SubIndicator
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