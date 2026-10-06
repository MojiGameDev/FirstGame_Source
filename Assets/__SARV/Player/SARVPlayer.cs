using __SARV.Player.SubPlayer;

namespace __SARV.Player
{
    public class SARVPlayer : MDSubSARVPlayerCharacter
    {
        protected override void Awake()
        {
            SharedCharacter.SetArgument(this);
            base.Awake();
        }
    }
}