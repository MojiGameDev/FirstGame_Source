using System;
using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Framework.Module.Footstep.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstep
{
    [Serializable]
    public abstract class SVSubFootstepFeet : SVSerializableLifeCycle
    {
        [BoxGroup("Feet")] [SerializeField] [RequiredListLength(1, 20)] [TableList]
        protected List<SVFoot> feet = new();
    }
}