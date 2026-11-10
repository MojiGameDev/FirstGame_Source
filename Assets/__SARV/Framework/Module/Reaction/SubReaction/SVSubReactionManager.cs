using System.Linq;
using __SARV.Framework.Module.Reaction.Entity;
using __SARV.Framework.Module.Reaction.Enum;

namespace __SARV.Framework.Module.Reaction.SubReaction
{
    public abstract class SVSubReactionManager : SVSubReactionSetting
    {
        public SVReaction GetReaction(SVReactionPower power, SVReactionDirection direction)
        {
            var targetReaction = reactions.FirstOrDefault(d => d.Direction == direction && d.Power == power);
            return targetReaction ?? defaultReaction;
        }
    }
}