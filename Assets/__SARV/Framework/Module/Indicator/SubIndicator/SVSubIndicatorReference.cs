using __SARV.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorReference : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [Title("Target")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SVPropertyComponent<GameObject> target = new SVGameObjectProperty();

        [FoldoutGroup("Reference")] [Title("FocusUIIdentifier")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SARVIdentifier focusUIIdentifier;

        [FoldoutGroup("Reference")] [Title("DistanceUIIdentifier")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SARVIdentifier distanceUIIdentifier;
    }
}