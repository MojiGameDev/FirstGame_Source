using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Framework.Argument;

namespace __SARV.Framework.Signal
{
    [SVTitle("OnUpdate")]
    [SVCategory(SVConstantCategory.Signal.LIFECYCLE)]
    [SVDescription("Called once every frame")]
    [Serializable]
    public class SVLifecycleSignalOnUpdate : SVSignalComponent
    {
        public override void HandleUpdate(float deltaTime)
        {
            Handler.Invoke(SVArgument.FromDeltaTime(deltaTime));
        }
    }
}