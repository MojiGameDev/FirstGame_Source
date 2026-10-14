using __SARV.Framework.Common.Component;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorSetting : SVSubInteractorEvent
    {
        [FoldoutGroup("Setting")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SVPropertyComponent<GameObject> target;

        [FoldoutGroup("Setting")] [SerializeField] [Required] [ChildGameObjectsOnly]
        protected Transform interactionPoint;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(0.5f, 3f)]
        protected float interactionRange = 1f;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(1f, 180f)]
        protected float interactionAngle = 45f;
    }
}