using System;
using System.Collections;
using System.Linq;
using __SARV.Common.Base;
using __SARV.Framework.Common.Reflection;
using __SARV.Framework.Module.Footstep.Source.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstepSource
{
    public abstract class SubFootstepSourceSetting : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Setting")] [BoxGroup("Setting/Row01", showLabel: false)] [SerializeField] [ValueDropdown(nameof(GetAllSourceTypes))] [OnValueChanged(nameof(OnFootstepSourceChanged))]
        private string source = "";

        [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [ShowIf(nameof(IsTypeValid))]
        private SVFootstepSource footstepSource;

        private bool IsTypeValid => !string.IsNullOrEmpty(source);

        private void OnFootstepSourceChanged()
        {
            var footstepSourceType = SVReflection.GetFootstepSourceTypeByPath(source);
            footstepSource = (SVFootstepSource)Activator.CreateInstance(footstepSourceType);
        }

        private IEnumerable GetAllSourceTypes()
        {
            var footstepSources = SVReflection.GetAllFootstepSources();
            return footstepSources.Select(d => new ValueDropdownItem(d, d));
        }
    }
}