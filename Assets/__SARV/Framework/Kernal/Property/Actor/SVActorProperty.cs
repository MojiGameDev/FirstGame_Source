using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Constant;

namespace __SARV.Framework.Kernal.Property.Actor
{
    [SVTitle("Actor")]
    [SVCategory(SVConstantCategory.Property.ACTOR)]
    [SVDescription("Includes all actors")]
    [SVIgnore]
    [Serializable]
    public class SVActorProperty : SVParentProperty<SVActor>
    {
        public override string ToString()
        {
            if (IsPropertyHasValue && !IsPropertyComponentNull)
            {
                return IsPropertyHasValue ? $"{GetValue(default).gameObject.name}" : "...";
            }

            return IsPropertyHasValue ? property : "...";
        }
    }
}