using __SARV.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Trait.Base
{
    public abstract class SVBaseRuntimeTrait : SVBaseTrait
    {
        [FoldoutGroup("Identifier")] [SerializeField] [PropertyOrder(int.MinValue)]
        protected SVIdentifier identifier;
    }
}