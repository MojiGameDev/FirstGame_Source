using __SARV.Core.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Player.SubPlayer
{
    public abstract class MDSubSARVPlayerCharacter : MDSubSARVPlayerAnimancer
    {
        [FoldoutGroup("Character")] [SerializeField] [HideLabel]
        private SVSharedCharacter sharedCharacter;

        public SVSharedCharacter SharedCharacter => sharedCharacter;

        protected override void Awake()
        {
            base.Awake();
            SharedCharacter.HandleAwake();
        }

        protected override void Start()
        {
            base.Start();
            SharedCharacter.HandleStart();
        }

        protected override void Update()
        {
            base.Update();
            SharedCharacter.HandleUpdate(Time.deltaTime);
        }
    }
}