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
        [FoldoutGroup("Type")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        protected SVActorType type = SVActorType.Player;

        public bool IsActorPlayer => type == SVActorType.Player;
    }
}