using System;
using __MD.Script.Core.Base;
using __MD.Script.WeeklyMap.Editor.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.WeeklyMap.Editor.Entity
{
    [Serializable]
    public class MDTask : MDSerializable
    {
        [FoldoutGroup("$Title")] [SerializeField] [Required] [HideLabel]
        private string title;

        [FoldoutGroup("$Title")] [SerializeField] [TextArea]
        private string description;

        [FoldoutGroup("$Title")] [SerializeField]
        private MDTaskStatus status = MDTaskStatus.InProgress;

        public string Title => string.IsNullOrEmpty(title) ? "..." : $"{title} ({Status.ToString()})";
        public string Description => description;
        public MDTaskStatus Status => status;
    }
}