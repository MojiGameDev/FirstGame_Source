using __SARV.Framework.Module.Actor.Enum;
using __SARV.Framework.Module.Interactor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorCharacter : SVSubActorAgent
    {
        [FoldoutGroup("Character")] [SerializeField] [LabelText("Height")] [PropertyRange(0.1f, 5f)] [OnValueChanged(nameof(OnCharacterChanged))]
        protected float characterHeight = 2f;

        [FoldoutGroup("Character")] [SerializeField] [LabelText("Center")] [OnValueChanged(nameof(OnCharacterChanged))]
        protected Vector3 characterCenter = Vector3.up;

        [FoldoutGroup("Character")] [SerializeField] [LabelText("Radius")] [PropertyRange(0.1f, 2f)] [OnValueChanged(nameof(OnCharacterChanged))]
        protected float characterRadius = 0.3f;

        public SARVInteractor CurrentInteractor { get; private set; }

        public void SetInteractor(SARVInteractor interactor)
        {
            CurrentInteractor = interactor;
        }

        public void SetMovementSpeed(SVActorSpeed actorSpeed)
        {
            currentSpeed = actorSpeed;
        }

        [OnInspectorInit]
        private void OnCharacterChanged()
        {
            if (characterMovement != null)
            {
                characterMovement.radius = characterRadius;
                characterMovement.height = characterHeight;
            }

            if (characterController != null)
            {
                characterController.radius = characterRadius;
                characterController.height = characterHeight;
                characterController.center = new Vector3(0, characterHeight / 2, 0);
            }

            if (aiPath != null)
            {
                aiPath.radius = characterRadius;
                aiPath.height = characterHeight;
            }
        }
    }
}