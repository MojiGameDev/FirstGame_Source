using System;
using System.Threading.Tasks;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Core.Enum;
using __SARV.Core.Utils;
using __SARV.Framework.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Instruction
{
    [SVTitle("LogText")]
    [SVCategory(SVConstantCategory.Instruction.DEBUG)]
    [SVDescription("Sends a log text to the Console")]
    [Serializable]
    public class SVDebugInstructionLogText : SVInstructionComponent
    {
        [FoldoutGroup("$GroupTitle")] [Title("LogLevel")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<SVLogLevel> logLevelProperty = new SVExternalPropertyLogLevel();

        [FoldoutGroup("$GroupTitle")] [Title("Text")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<string> textProperty = new SVStringProperty();

        private string GroupTitle => $"Sends {(string.IsNullOrEmpty(textProperty.Value) ? "..." : textProperty.Value)} to the console";

        public override Task Execute()
        {
            SVComponentUtils.DebugLog(logLevelProperty.Value, textProperty.Value);
            return OkResult;
        }
    }
}