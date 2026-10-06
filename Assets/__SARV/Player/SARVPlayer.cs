using __SARV.Player.SubPlayer;

namespace __SARV.Player
{
    public class SARVPlayer : SVSubSARVPlayerCharacter
    {
        protected override void Awake()
        {
            SharedStateMachine.SetArgument(this);
            base.Awake();
        }
    }
}