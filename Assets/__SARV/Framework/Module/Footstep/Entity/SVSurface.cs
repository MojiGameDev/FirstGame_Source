using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.Entity
{
    [Serializable]
    public class SVSurface : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private string title;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private Texture texture;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVIdentifier footStateIdentifier;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVIdentifier effectIdentifier;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [PropertyRange(0.2f, 5f)]
        private float particleLifetime = 0.3f;

        private string GroupTitle => $"{(string.IsNullOrEmpty(title) ? "..." : title)} - {(string.IsNullOrEmpty(footStateIdentifier) ? "..." : footStateIdentifier.SkipWords(2))} - {(texture == null ? "..." : texture.name)}";
    }
}