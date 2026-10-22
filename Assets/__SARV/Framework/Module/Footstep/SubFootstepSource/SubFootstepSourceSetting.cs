using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using __SARV.Common.Base;
using __SARV.Framework.Common.Reflection;
using __SARV.Framework.Module.Footstep.Entity;
using __SARV.Framework.Module.Footstep.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstepSource
{
    public abstract class SubFootstepSourceSetting : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Setting")] [SerializeField] [OnValueChanged(nameof(OnFootstepSourceTypeChanged))]
        protected SVFootstepSourceType type = SVFootstepSourceType.Mesh;

        [FoldoutGroup("Setting")] [SerializeField] [Required] [ShowIf(nameof(IsFootstepSourceTypeTerrain))]
        protected Terrain terrain;

        private bool IsFootstepSourceTypeTerrain => type == SVFootstepSourceType.Terrain;

        private void OnFootstepSourceTypeChanged()
        {
            if (type == SVFootstepSourceType.Terrain)
            {
                terrain = gameObject.GetComponent<Terrain>();
            }
        }
    }
}