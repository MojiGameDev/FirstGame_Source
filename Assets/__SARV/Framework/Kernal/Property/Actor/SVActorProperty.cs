using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.Actor;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Actor")]
    [SVCategory(SVConstantCategory.Property.ACTOR)]
    [SVDescription("Includes all actors")]
    [SVIgnore]
    [Serializable]
    public class SVActorProperty : SVParentProperty<SVActor>
    {
    }
}