using __SARV.Framework.Module.Actor.Access;
using __SARV.Framework.Module.Actor.Enum;
using __SARV.Framework.Module.Actor.SubActor;

namespace __SARV.Framework.Module.Actor
{
    public class SVActor : SVSubActorInstruction
    {
        protected override void Awake()
        {
            if (type == SVActorType.Player)
            {
                SVAccessPlayer.Initial(this);
            }
            base.Awake();
        }
    }
}