using System.Threading.Tasks;
using __SARV.Common.Base;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Identifier;
using __SARV.Framework.Module.Interactor;
using __SARV.Framework.Module.Melee;
using UnityEngine;

namespace __SARV.Framework.Module.Actor
{
    public abstract class SVActor : SVOverrideMonoBehaviour
    {
        public Vector3 Position => transform.position;
        public Vector3 Forward => transform.forward;

        public abstract void ChangeBehaviorTo(SARVIdentifier stateIdentifier);
        public abstract void SetInteractor(SARVInteractor interactor);
        public abstract void AttachProp(GameObject prop, SVBone bone, Vector3 position, Vector3 rotation);
        public abstract void Equip(SARVMelee melee);
        public abstract void Unequip();
        public abstract SARVMelee GetCurrentMelee();
    }
}