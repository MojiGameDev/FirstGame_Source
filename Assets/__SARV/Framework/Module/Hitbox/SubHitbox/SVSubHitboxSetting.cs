using __SARV.Common.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Hitbox.SubHitbox
{
    public abstract class SVSubHitboxSetting : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Setting")] [SerializeField]
        protected Vector3 hitboxSize = new(0.5f, 0.5f, 0.2f);

        [FoldoutGroup("Setting")] [SerializeField]
        protected Vector3 hitboxOffset = new(0.5f, 0.5f, 0.2f);
    }
}