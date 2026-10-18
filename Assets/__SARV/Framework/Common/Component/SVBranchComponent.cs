using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Common.Component
{
    [Serializable]
    public abstract class SVBranchComponent : SVComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [HorizontalGroup("$" + nameof(GroupTitle) + "/HorizontalGroup", 90)] [SerializeField] [LabelText("Not?")]
        private bool not;

        [FoldoutGroup("$" + nameof(GroupTitle))] [HorizontalGroup("$" + nameof(GroupTitle) + "/HorizontalGroup", 90)] [SerializeField] [LabelText("Disabled?")]
        private bool disabled;

        protected virtual string GroupTitle => string.Empty;
        public bool Not => not;
        public bool Disabled => disabled;

        public virtual bool IsTrue(SVArgument argument)
        {
            return false;
        }
    }
}