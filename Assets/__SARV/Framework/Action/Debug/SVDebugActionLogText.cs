using System;
using System.Threading.Tasks;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Core.Enum;
using __SARV.Core.Utils;
using __SARV.Framework.Property;
using __SARV.Framework.Property.External;
using SingularityGroup.HotReload;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Action
{
    [SVTitle("LogText")]
    [SVCategory(SVConstantCategory.Action.DEBUG)]
    [SVDescription("Sends a log text to the Console")]
    [Serializable]
    public class SVDebugActionLogText : SVActionComponent
    {
        [Title("LogLevel")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<SVLogLevel> logLevelProperty = new SVExternalPropertyLogLevel();

        [Title("Text")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<string> textProperty = new SVStringProperty();

        public override Task Execute()
        {
            SVComponentUtils.DebugLog(logLevelProperty.Value, textProperty.Value);
            return OkResult;
        }
    }
}