using __SARV.Core.Access;
using __SARV.Player.SubPlayer;

namespace __SARV.Player
{
    public class SARVPlayer : SVSubSARVPlayerCharacter
    {
        protected override void Awake()
        {
            SVAccessPlayer.Initial(this);
            base.Awake();
        }
    }
}