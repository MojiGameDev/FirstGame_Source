using System.Collections.Generic;
using __MD.Script.Cameras.Entity;
using __MD.Script.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.Cameras.SubCameraBrain
{
    public abstract class MDSubCameraBrainShakePower : MDSubCameraBrainSwitcher
    {
        [FoldoutGroup("ShakePower")] [SerializeField] [Required]
        public MDShakePowerDatabase shakePowerDatabase;

        protected readonly Dictionary<MDIdentifier, MDShakePower> ShakePowerLookup = new();

        protected override void Start()
        {
            base.Start();
            HandleBuildShakePowerLookup();
        }

        private void HandleBuildShakePowerLookup()
        {
            foreach (var shakePower in shakePowerDatabase.ShakePowers)
            {
                ShakePowerLookup.Add(shakePower.Identifier, shakePower);
            }
        }
    }
}