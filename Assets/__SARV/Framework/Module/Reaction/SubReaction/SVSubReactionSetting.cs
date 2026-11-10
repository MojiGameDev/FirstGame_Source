using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Framework.Module.Reaction.Entity;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Reaction.SubReaction
{
    public abstract class SVSubReactionSetting : SVScriptableObject
    {
        [FoldoutGroup("Setting")] [BoxGroup("Setting/Specific")] [SerializeField]
        private List<SVReaction> reactions = new();

        [FoldoutGroup("Setting")] [BoxGroup("Setting/Default")] [SerializeField] [Required] [HideLabel]
        private StringAsset defaultReactionAlias;

        public IReadOnlyList<SVReaction> Reactions => reactions;
        public StringAsset DefaultReactionAlias => defaultReactionAlias;
    }
}