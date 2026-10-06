using __SARV.Play.SubGame;
using Rewired;

namespace __SARV.Play
{
    public class SARVGame : SVSubSARVGameInput
    {
        private const int PLAYER_ID = 0;

        private Rewired.Player _player;

        public Rewired.Player Player => _player;

        protected override void Awake()
        {
            base.Awake();
            _player = ReInput.players.GetPlayer(PLAYER_ID);
        }
    }
}