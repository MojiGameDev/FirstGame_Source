using __SARV.Framework.Module.Actor.Access;
using __SARV.Framework.Module.Actor.Enum;
using __SARV.Framework.Module.Actor.SubActor;

namespace __SARV.Framework.Module.Actor
{
    public class SARVActor : SVSubActorCharacter
    {
        protected override void Awake()
        {
            base.Awake();
            if (type == SVActorType.Player)
            {
                SVAccessPlayer.Initial(this);
            }
            StateMachine.HandleSetActor(this);
        }
    }
}