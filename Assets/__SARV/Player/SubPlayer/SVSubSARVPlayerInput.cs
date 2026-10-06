using __SARV.Play;
using Rewired;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Player.SubPlayer
{
    public abstract class SVSubSARVPlayerInput : SVSubSARVPlayerReference
    {
        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("MoveHorizontal")]
        private string playerMoveHorizontalKey = "PlayerMoveHorizontal";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("MoveVertical")]
        private string playerMoveVerticalKey = "PlayerMoveVertical";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("Sprint")]
        private string playerSprintKey = "PlayerSprint";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("Interact")]
        private string playerInteractKey = "PlayerInteract";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("Roll")]
        private string playerRollKey = "PlayerRoll";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("AttackSword")]
        private string playerAttackSwordKey = "PlayerAttackSword";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("AttackBow")]
        private string playerAttackBowKey = "PlayerAttackBow";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("AttackSpear")]
        private string playerAttackSpearKey = "PlayerAttackSpear";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("AttackDualSword")]
        private string playerAttackDualSwordKey = "PlayerAttackDualSword";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("ComboSwitchA")]
        private string playerComboSwitchAKey = "PlayerComboSwitchA";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("ComboSwitchB")]
        private string playerComboSwitchBKey = "PlayerComboSwitchB";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("ComboSwitchC")]
        private string playerComboSwitchCKey = "PlayerComboSwitchC";

        [FoldoutGroup("Input")] [BoxGroup("Input/Key")] [SerializeField] [LabelText("ComboSwitchD")]
        private string playerComboSwitchDKey = "PlayerComboSwitchD";

        [FoldoutGroup("Input")] [BoxGroup("Input/Debug")] [HorizontalGroup("Input/Debug/MovementDirection")] [SerializeField] [ReadOnly]
        private Vector3 inputMovementDirection;

        private int _playerMoveHorizontalId;
        private int _playerMoveVerticalId;
        private int _playerSprintId;
        private int _playerInteractId;
        private int _playerRollId;
        private int _playerAttackSwordId;
        private int _playerAttackBowId;
        private int _playerAttackSpearId;
        private int _playerAttackDualSwordId;
        private int _playerComboSwitchAId;
        private int _playerComboSwitchBId;
        private int _playerComboSwitchCId;
        private int _playerComboSwitchDId;

        private float InputMoveHorizontal => SARVGame.Instance.Player.GetAxisRaw(_playerMoveHorizontalId);
        private float InputMoveVertical => SARVGame.Instance.Player.GetAxisRaw(_playerMoveVerticalId);
        public bool InputSprint => SARVGame.Instance.Player.GetButton(_playerSprintId);
        // public bool InputInteract => SARVGame.Instance.Player.GetButtonDown(_playerInteractId);
        // public bool InputRoll => SARVGame.Instance.Player.GetButtonDown(_playerRollId);
        // public bool InputAttackSword => SARVGame.Instance.Player.GetButtonDown(_playerAttackSwordId);
        // public bool InputAttackBow => SARVGame.Instance.Player.GetButtonDown(_playerAttackBowId);
        // public bool InputAttackSpear => SARVGame.Instance.Player.GetButtonDown(_playerAttackSpearId);
        // public bool InputAttackDualSword => SARVGame.Instance.Player.GetButtonDown(_playerAttackDualSwordId);
        // public bool InputComboSwitchA => SARVGame.Instance.Player.GetButtonDown(_playerComboSwitchAId);
        // public bool InputComboSwitchB => SARVGame.Instance.Player.GetButtonDown(_playerComboSwitchBId);
        // public bool InputComboSwitchC => SARVGame.Instance.Player.GetButtonDown(_playerComboSwitchCId);
        // public bool InputComboSwitchD => SARVGame.Instance.Player.GetButtonDown(_playerComboSwitchDId);

        public Vector3 InputMovementDirection => inputMovementDirection;

        protected override void Awake()
        {
            base.Awake();
            _playerMoveHorizontalId = ReInput.mapping.GetActionId(playerMoveHorizontalKey);
            _playerMoveVerticalId = ReInput.mapping.GetActionId(playerMoveVerticalKey);
            _playerSprintId = ReInput.mapping.GetActionId(playerSprintKey);
            // _playerInteractId = ReInput.mapping.GetActionId(playerInteractKey);
            // _playerRollId = ReInput.mapping.GetActionId(playerRollKey);
            // _playerAttackSwordId = ReInput.mapping.GetActionId(playerAttackSwordKey);
            // _playerAttackBowId = ReInput.mapping.GetActionId(playerAttackBowKey);
            // _playerAttackSpearId = ReInput.mapping.GetActionId(playerAttackSpearKey);
            // _playerAttackDualSwordId = ReInput.mapping.GetActionId(playerAttackDualSwordKey);
            // _playerComboSwitchAId = ReInput.mapping.GetActionId(playerComboSwitchAKey);
            // _playerComboSwitchBId = ReInput.mapping.GetActionId(playerComboSwitchBKey);
            // _playerComboSwitchCId = ReInput.mapping.GetActionId(playerComboSwitchCKey);
            // _playerComboSwitchDId = ReInput.mapping.GetActionId(playerComboSwitchDKey);
        }

        protected override void Update()
        {
            base.Update();
            HandleMovementDirection();
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