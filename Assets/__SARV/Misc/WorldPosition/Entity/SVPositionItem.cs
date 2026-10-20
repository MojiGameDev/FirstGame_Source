using System;
using __SARV.Common.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Misc.WorldPosition.Entity
{
    [Serializable]
    public class SVPositionItem : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HorizontalGroup("$" + nameof(GroupTitle) + "/Group")]
        private string title;

        [FoldoutGroup("$" + nameof(GroupTitle))]
        [HorizontalGroup("$" + nameof(GroupTitle) + "/Group", width: 30)]
        [Button(ButtonSizes.Large)]
        public void Go()
        {
            target.transform.position = position;
        }

        [SerializeField] [HideInInspector] private Vector3 position;
        [SerializeField] [HideInInspector] private GameObject target;

        private string GroupTitle => string.IsNullOrEmpty(title) ? "" : $"{title} ({target.name})";

        public SVPositionItem(string positionTitle, GameObject target, Vector3 position)
        {
            title = positionTitle;
            this.target = target;
            this.position = position;
        }
    }
}