using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Enum;
using __SARV.Framework.Common.Utils;
using __SARV.Framework.Kernal.Argument;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("LogText")]
    [SVCategory(SVConstantCategory.Instruction.DEBUG)]
    [SVDescription("Sends a log text to the Console")]
    [Serializable]
    public class SVDebugInstructionLogText : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("LogLevel")] [SerializeField] [HideLabel] [HideReferenceObjectPicker]
        private SVLogLevel logLevel = SVLogLevel.Info;

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("Text")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<string> text = new SVStringProperty();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Sends {text} to the console";

        protected override Task ExecuteInternal(SVArgument argument)
        {
            SVComponentUtils.DebugLog(logLevel, text.Value);
            return SVTaskUtils.OK_RESULT;
        }
    }
}