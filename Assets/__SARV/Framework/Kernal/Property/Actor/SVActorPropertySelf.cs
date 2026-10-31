using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.Actor;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Self")]
    [SVCategory(SVConstantCategory.Property.ACTOR)]
    [SVDescription("Self Actor")]
    [Serializable]
    public class SVActorPropertySelf : SVPropertyComponent<SVActor>
    {
        public override string ToString()
        {
            return "Self";
        }

        public override SVActor GetValue(SVArgument argument)
        {
            var actor = argument.Self.GetComponent<SVActor>();
            return actor;
        }
    }
}