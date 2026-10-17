using System;
using __SARV.Common.Access;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;

namespace __SARV.Framework.Kernal.Property.Actor
{
    [SVTitle("Player")]
    [SVCategory(SVConstantCategory.Property.ACTOR)]
    [SVDescription("Player Actor")]
    [Serializable]
    public class SVActorPropertyPlayer : SVPropertyComponent<SVActor>
    {
        public override string ToString()
        {
            return "Player";
        }

        public override SVActor GetValue(SVArgument argument)
        {
            return SVAccessPlayer.Instance;
        }
    }
}