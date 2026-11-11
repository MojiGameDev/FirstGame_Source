using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Framework.Module.Transition.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Transition.SubTransition
{
    public abstract class SVSubTransitionCollection : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Collection")] [SerializeField]
        protected List<SVTransition> transitions = new();
    }
}