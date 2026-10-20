using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Common.Utils;
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

        public virtual Task<SVInstructionResult> Execute(SVArgument argument)
        {
            if (Disabled)
            {
                return SVInstructionResult.DEFAULT_RESULT;
            }

            return ExecuteInternal(argument);
        }

        protected abstract Task<SVInstructionResult> ExecuteInternal(SVArgument argument);
    }
}