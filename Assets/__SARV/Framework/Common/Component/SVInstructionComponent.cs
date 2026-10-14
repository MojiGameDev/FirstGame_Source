using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Utils;
using __SARV.Framework.Kernal.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Common.Component
{
    [Serializable]
    public abstract class SVInstructionComponent : SVComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [LabelText("Disabled?")]
        private bool disabled;

        protected virtual string GroupTitle => string.Empty;
        public bool Disabled => disabled;

        public virtual Task Execute(SVArgument argument)
        {
            if (Disabled)
            {
                return SVTaskUtils.OK_RESULT;
            }
            return ExecuteInternal(argument);
        }

        protected virtual Task ExecuteInternal(SVArgument argument)
        {
            return SVTaskUtils.OK_RESULT;
        }
    }
}