using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Core.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property.External
{
    [SVTitle("LogLevel")]
    [SVCategory(SVConstantCategory.Property.EXTERNAL)]
    [SVDescription("The type of log message that will be printed to the console")]
    [Serializable]
    [SVIgnore]
    public class SVExternalPropertyLogLevel : SVPropertyComponent<SVLogLevel>
    {
        [SerializeField] [HideLabel] private SVLogLevel value = SVLogLevel.Info;

        public override SVLogLevel Value => value;

        public override string ToString()
        {
            return value.ToString();
        }
    }
}