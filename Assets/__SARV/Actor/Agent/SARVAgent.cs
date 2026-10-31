using System.Threading.Tasks;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Actor;
using __SARV.Framework.Module.Identifier;
using __SARV.Framework.Module.Interactor;
using __SARV.Framework.Module.Melee;
using UnityEngine;

namespace __SARV.Actor.Agent
{
    public class SARVAgent : SVActor
    {
        protected override void Awake()
        {
            //SetArgument(this);
            base.Awake();
        }

        public override void ChangeBehaviorTo(SARVIdentifier stateIdentifier)
        {
            throw new System.NotImplementedException();
        }

        public override void SetInteractor(SARVInteractor interactor)
        {
            throw new System.NotImplementedException();
        }

        public override void AttachProp(GameObject prop, SVBone bone, Vector3 position, Vector3 rotation)
        {
            throw new System.NotImplementedException();
        }

        public override void Equip(SARVMelee melee)
        {
            throw new System.NotImplementedException();
        }

        public override void Unequip()
        {
            throw new System.NotImplementedException();
        }

        public override SARVMelee GetCurrentMelee()
        {
            throw new System.NotImplementedException();
        }
    }
}