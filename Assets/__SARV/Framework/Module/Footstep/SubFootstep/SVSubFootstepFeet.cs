using System;
using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstep
{
    [Serializable]
    public abstract class SVSubFootstepFeet : SVSerializableLifeCycle
    {
        [BoxGroup("Feet")] [SerializeField] [RequiredListLength(1, 20)]
        protected List<SARVFoot> feet = new();

        protected Dictionary<SARVIdentifier, SARVFoot> RuntimeFeet = new();

        public override void HandleAwake()
        {
            base.HandleAwake();
            foreach (var foot in feet)
            {
                RuntimeFeet.Add(foot.FootIdentifier, foot);
            }
        }

        public void AddFeet(GameObject sarvFeet)
        {
            feet.Clear();
            foreach (var foot in sarvFeet.GetComponentsInChildren<SARVFoot>(true))
            {
                feet.Add(foot);
            }
        }
    }
}