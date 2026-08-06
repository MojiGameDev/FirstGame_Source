using System.Collections.Generic;
using __MD.Script.Cameras.Entity;
using __MD.Script.Core.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.Cameras.SubShakePowerDatabase
{
    public abstract class MDSubShakePowerDatabaseSetting : MDScriptableObject
    {
        [FoldoutGroup("Setting")] [SerializeField] [RequiredListLength(1, 5)] [OnValueChanged(nameof(OnCameraShakesChanged))]
        private List<MDShakePower> shakePowers = new();

        public List<MDShakePower> ShakePowers => shakePowers;

        private void OnCameraShakesChanged()
        {
            if (ShakePowers is not { Count: > 0 })
            {
                return;
            }

            var seen = new HashSet<string>();

            foreach (var shakePower in ShakePowers)
            {
                if (shakePower.Identifier == null)
                {
                    return;
                }

                if (!seen.Add(shakePower.Identifier))
                {
                    shakePower.ClearIdentifier();
                }
            }
        }
    }
}