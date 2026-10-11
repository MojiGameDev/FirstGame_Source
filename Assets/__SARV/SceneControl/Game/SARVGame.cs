using __SARV.SceneControl.Game.SubGame;
using Rewired;

namespace __SARV.SceneControl.Game
{
    public class SARVGame : SVSubGamePool
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