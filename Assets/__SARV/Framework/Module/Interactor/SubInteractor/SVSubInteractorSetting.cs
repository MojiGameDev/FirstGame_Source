using System.Collections.Generic;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorSetting : SVSubInteractorEvent
    {
        [FoldoutGroup("Setting")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SVPropertyComponent<GameObject> target = new SVGameObjectProperty();

        [FoldoutGroup("Setting")] [SerializeField] [Required] [RequiredListLength(1, 8)]
        protected List<Transform> interactionPoints = new();

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(0.5f, 3f)]
        protected float interactionRange = 1f;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(1f, 180f)]
        protected float interactionAngle = 45f;
        
        public Transform CurrentInteractionPoint { get; protected set; }
        public bool CanInteract { get; protected set; }

    }
}