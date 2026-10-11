using __SARV.Service.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Trait.Base
{
    public abstract class SVBaseRuntimeTrait : SVBaseTrait
    {
        [FoldoutGroup("Identifier")] [SerializeField] [PropertyOrder(int.MinValue)]
        protected SARVIdentifier identifier;
    }
}