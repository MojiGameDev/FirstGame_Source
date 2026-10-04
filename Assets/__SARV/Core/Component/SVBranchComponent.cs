using System;
using __SARV.Core.Component.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Core.Component
{
    [Serializable]
    public class SVBranchComponent : SVComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [HorizontalGroup("$" + nameof(GroupTitle) + "/HorizontalGroup", 90)] [SerializeField] [LabelText("Not?")]
        private bool not;

        [FoldoutGroup("$" + nameof(GroupTitle))] [HorizontalGroup("$" + nameof(GroupTitle) + "/HorizontalGroup", 90)] [SerializeField] [LabelText("Disabled?")]
        private bool disabled;

        protected virtual string GroupTitle => string.Empty;
        public bool Not => not;
        public bool Disabled => disabled;

        public virtual bool IsTrue()
        {
            return false;
        }
    }
}