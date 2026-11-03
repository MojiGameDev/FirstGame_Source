using __SARV.Framework.Module.Actor.Enum;
using __SARV.Framework.Module.Interactor;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorCharacter : SVSubActorAgent
    {
        public SARVInteractor CurrentInteractor { get; private set; }

        public void SetInteractor(SARVInteractor interactor)
        {
            CurrentInteractor = interactor;
        }
        
        public void SetMovementSpeed(SVActorSpeed actorSpeed)
        {
            currentSpeed = actorSpeed;
        }
    }
}