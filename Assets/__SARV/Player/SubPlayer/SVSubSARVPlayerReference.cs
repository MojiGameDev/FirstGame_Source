using __SARV.Core.Base;
using ECM2;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Player.SubPlayer
{
    public abstract class SVSubSARVPlayerReference : SVCharacter
    {
        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        private Character character;
    }
}