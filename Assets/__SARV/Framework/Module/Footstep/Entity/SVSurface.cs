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
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private string title;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private Texture texture;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private SARVIdentifier footStateIdentifier;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private SARVIdentifier audioIdentifier;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private SARVIdentifier particleIdentifier;

        private string GroupTitle => $"{(string.IsNullOrEmpty(title) ? "..." : title)} - {(texture == null ? "..." : texture.name)}";
    }
}