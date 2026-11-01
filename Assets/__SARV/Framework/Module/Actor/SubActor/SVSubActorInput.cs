using System.Threading.Tasks;
using __SARV.SceneControl.Game;
using Rewired;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorInput : SVSubActorReference
    {
        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("MoveHorizontal")] [ShowIf(nameof(IsActorPlayer))]
        private string playerMoveHorizontalKey = "PlayerMoveHorizontal";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("MoveVertical")] [ShowIf(nameof(IsActorPlayer))]
        private string playerMoveVerticalKey = "PlayerMoveVertical";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("Sprint")] [ShowIf(nameof(IsActorPlayer))]
        private string playerSprintKey = "PlayerSprint";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("Interact")] [ShowIf(nameof(IsActorPlayer))]
        private string playerInteractKey = "PlayerInteract";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("Roll")] [ShowIf(nameof(IsActorPlayer))]
        private string playerRollKey = "PlayerRoll";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("Attack")] [ShowIf(nameof(IsActorPlayer))]
        private string playerAttackKey = "PlayerAttack";

        [FoldoutGroup("Input")] [BoxGroup("Input/Debug")] [HorizontalGroup("Input/Debug/MovementDirection")] [SerializeField] [ReadOnly] [ShowIf(nameof(IsActorPlayer))]
        private Vector3 inputMovementDirection;

        private int _playerMoveHorizontalId;
        private int _playerMoveVerticalId;
        private int _playerSprintId;
        private int _playerInteractId;
        private int _playerRollId;
        private int _playerAttackId;

        private float InputMoveHorizontal => SARVGame.Instance.Player.GetAxisRaw(_playerMoveHorizontalId);
        private float InputMoveVertical => SARVGame.Instance.Player.GetAxisRaw(_playerMoveVerticalId);
        public bool InputSprint => SARVGame.Instance.Player.GetButton(_playerSprintId);

        public bool InputInteract => SARVGame.Instance.Player.GetButtonDown(_playerInteractId);
        // public bool InputRoll => SARVGame.Instance.Player.GetButtonDown(_playerRollId);
        // public bool InputAttack => SARVGame.Instance.Player.GetButtonDown(_playerAttackId);

        public Vector3 InputMovementDirection => inputMovementDirection;

        private TaskCompletionSource<bool> _interactPressed;

        protected override void Awake()
        {
            base.Awake();
            _playerMoveHorizontalId = ReInput.mapping.GetActionId(playerMoveHorizontalKey);
            _playerMoveVerticalId = ReInput.mapping.GetActionId(playerMoveVerticalKey);
            _playerSprintId = ReInput.mapping.GetActionId(playerSprintKey);
            _playerInteractId = ReInput.mapping.GetActionId(playerInteractKey);
            // _playerRollId = ReInput.mapping.GetActionId(playerRollKey);
            // _playerAttackId = ReInput.mapping.GetActionId(playerAttackKey);
        }

        protected override void Update()
        {
            base.Update();
            HandleMovementDirection();
            HandleInteractPressed();
        }

        public Task WaitForInteract()
        {
            _interactPressed = new TaskCompletionSource<bool>();
            return _interactPressed.Task;
        }

        private void HandleInteractPressed()
        {
            if (InputInteract)
            {
                _interactPressed?.TrySetResult(true);
            }
        }

        private void HandleMovementDirection()
        {
            inputMovementDirection = Vector3.zero;
            inputMovementDirection += Vector3.right * InputMoveHorizontal;
            inputMovementDirection += Vector3.forward * InputMoveVertical;
            inputMovementDirection.Normalize();
        }
    }
}