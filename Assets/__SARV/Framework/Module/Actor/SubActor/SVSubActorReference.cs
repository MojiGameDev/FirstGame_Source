using System;
using __SARV.Framework.Common.Argument;
using Animancer;
using ECM2;
using Pathfinding;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorReference : SVSubActorType
    {
        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        protected AnimancerComponent animancerComponent;

        [FoldoutGroup("Reference")] [SerializeField] [ShowIf(nameof(IsActorPlayer))] [SceneObjectsOnly] [Required] [HideLabel]
        protected Character ecmCharacter;

        [FoldoutGroup("Reference")] [SerializeField] [ShowIf(nameof(IsActorPlayer))] [SceneObjectsOnly] [Required] [HideLabel]
        protected CharacterMovement characterMovement;

        [FoldoutGroup("Reference")] [SerializeField] [ShowIf(nameof(IsActorAgent))] [SceneObjectsOnly] [Required] [HideLabel]
        protected AIPath aiPath;

        [FoldoutGroup("Reference")] [SerializeField] [ShowIf(nameof(IsActorAgent))] [SceneObjectsOnly] [Required] [HideLabel]
        protected AIDestinationSetter aiDestinationSetter;

        [FoldoutGroup("Reference")] [SerializeField] [ShowIf(nameof(IsActorAgent))] [SceneObjectsOnly] [Required] [HideLabel]
        protected CharacterController characterController;

        public Character ECMCharacter => ecmCharacter;
        public AnimancerComponent AnimancerComponent => animancerComponent;
        public SVArgument Argument;
        public Vector3 Position => transform.position;
        public Vector3 Forward => transform.forward;
        public CharacterMovement CharacterMovement => characterMovement;
        public AIPath AIPath => aiPath;
        public AIDestinationSetter AIDestinationSetter => aiDestinationSetter;
        public CharacterController CharacterController => characterController;

        protected override void Awake()
        {
            base.Awake();
            Argument = SVArgument.Create(gameObject);
        }
    }
}