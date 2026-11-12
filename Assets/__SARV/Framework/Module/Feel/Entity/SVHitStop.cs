using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Feel.Entity
{
    [Serializable]
    public class SVHitStop : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        public SARVIdentifier identifier;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [PropertyRange(0.01f, 1f)]
        public float duration = 0.05f;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [PropertyRange(0.01f, 1f)]
        public float timeScale = 0.05f;

        private string GroupTitle => $"{(string.IsNullOrEmpty(identifier) ? "..." : identifier.SkipWords(2))} - Time Scale: {timeScale} | Duration: {duration}s";

        public SARVIdentifier Identifier => identifier;
        public float Duration => duration;
        public float TimeScale => timeScale;
    }
}