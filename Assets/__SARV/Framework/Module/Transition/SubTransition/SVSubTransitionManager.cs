using __SARV.Framework.Common.Argument;
using __SARV.Framework.Module.Actor;

namespace __SARV.Framework.Module.Transition.SubTransition
{
    public abstract class SVSubTransitionManager : SVSubTransitionCollection
    {
        public bool Evaluate(SVArgument argument)
        {
            foreach (var transition in transitions)
            {
                var isBranchesPassed = transition.Branch.IsBranchesPassed(argument);
                if (isBranchesPassed)
                {
                    var actor = argument.Self.GetComponent<SARVActor>();
                    actor.StateMachine.ChangeBehaviorTo(transition.Behavior);
                    return true;
                }
            }

            return false;
        }
    }
}