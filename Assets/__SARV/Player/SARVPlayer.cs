using __SARV.Core.Base;
using __SARV.Player.SubPlayer;

namespace __SARV.Player
{
    public class SARVPlayer : MDSubSARVPlayerAnimancer
    {
        protected override void Awake()
        {
            SetArgument(this);
            base.Awake();
        }
    }
}