using System;
using __SARV.Framework.Common.Argument;
using Animancer;
using ECM2;
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

        public Character ECMCharacter => ecmCharacter;
        public AnimancerComponent AnimancerComponent => animancerComponent;
        protected SVArgument Argument;
        public Vector3 Position => transform.position;
        public Vector3 Forward => transform.forward;

        protected override void Awake()
        {
            base.Awake();
            Argument = SVArgument.Create(gameObject);
        }
    }
}