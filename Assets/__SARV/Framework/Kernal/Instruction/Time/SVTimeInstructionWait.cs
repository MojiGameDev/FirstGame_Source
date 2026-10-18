using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Enum;
using __SARV.Framework.Common.Utils;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction.Time
{
    [SVTitle("Wait")]
    [SVCategory(SVConstantCategory.Instruction.TIME)]
    [SVDescription("Wait for the specified duration, optionally using real time")]
    [Serializable]
    public class SVTimeInstructionWait : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [PropertyRange(0f, 10f)]
        private float duration = 2;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [LabelText("RealTime?")]
        private bool realTime = false;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Wait {duration} seconds";

        protected override async Task ExecuteInternal(SVArgument argument)
        {
            await SVTaskUtils.Wait(duration, realTime);
        }
    }
}