using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFoot
{
    public abstract class SVSubFootReference : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeField] [Required]
        private SARVIdentifier footIdentifier;
        
        public SARVIdentifier FootIdentifier => footIdentifier;
    }
}