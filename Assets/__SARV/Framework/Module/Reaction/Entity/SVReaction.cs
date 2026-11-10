using System;
using __SARV.Common.Base;
using __SARV.Common.Extension;
using __SARV.Framework.Module.Reaction.Enum;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Reaction.Entity
{
    [Serializable]
    public class SVReaction : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private SVReactionPower power = SVReactionPower.Any;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private SVReactionDirection direction = SVReactionDirection.Any;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private StringAsset alias;

        public string GroupTitle => $"Receive a {power.ToReadableString()} Hit from the {direction.ToReadableString()}";
        public SVReactionPower Power => power;
        public SVReactionDirection Direction => direction;
        public StringAsset Alias => alias;
    }
}