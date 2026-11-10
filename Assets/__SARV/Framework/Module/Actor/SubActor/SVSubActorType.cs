using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Actor.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorType : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Type")] [SerializeField] [SceneObjectsOnly] [Required]
        protected SVActorType type = SVActorType.Player;

        [FoldoutGroup("Type")] [SerializeField] [SceneObjectsOnly] [Required] [ShowIf(nameof(IsActorAgent))]
        protected SVAgentType agentType = SVAgentType.Enemy;

        public bool IsActorPlayer => type == SVActorType.Player;
        public bool IsActorAgent => type == SVActorType.Agent;
        public bool IsAgentAlly => IsActorAgent && agentType == SVAgentType.Ally;
        public bool IsAgentEnemy => IsActorAgent && agentType == SVAgentType.Enemy;
        public bool IsAgentAnimal => IsActorAgent && agentType == SVAgentType.Animal;
    }
}