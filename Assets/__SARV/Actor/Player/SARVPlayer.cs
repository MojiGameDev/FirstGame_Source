using __SARV.Actor.Player.SubPlayer;
using __SARV.Common.Access;

namespace __SARV.Actor.Player
{
    public class SARVPlayer : SVSubPlayerCharacter
    {
        protected override void Awake()
        {
            SVAccessPlayer.Initial(this);
            base.Awake();
        }
    }
}