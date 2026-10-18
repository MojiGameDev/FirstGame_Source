using __SARV.Common.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Common.Base
{
    public class SVKernal : SVOverrideMonoBehaviour
    {
        [BoxGroup("Purpose", showLabel: false)] [SerializeField] [HideLabel] [OnValueChanged(nameof(OnDescriptionChanged))]
        private string description = "";

        private void OnDescriptionChanged()
        {
            if (!string.IsNullOrEmpty(description))
            {
                gameObject.name = description;
            }
        }
    }
}