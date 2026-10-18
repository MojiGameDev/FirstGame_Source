using Rewired;

namespace __SARV.SceneControl.Game.SubGame
{
    public abstract class SVSubGameInput : SVSubGameLocalizer
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