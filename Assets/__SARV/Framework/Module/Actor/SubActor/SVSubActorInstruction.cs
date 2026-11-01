using __SARV.Common.Extension;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Interactor;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorInstruction : SVSubActorAgent
    {
        public void SetInteractor(SARVInteractor interactor)
        {
            CurrentInteractor = interactor;
        }

        public void AttachProp(GameObject prop, SVBone bone, Vector3 position, Vector3 rotation)
        {
            var index = PropCache.IndexOf(prop);
            if (index == -1)
            {
                var boneTransform = bone.GetTransform(animancerComponent.Animator);
                var instance = UnityEngine.Object.Instantiate(prop, boneTransform, true);
                instance.transform.localPosition = position;
                instance.transform.localRotation = Quaternion.Euler(rotation);
                PropCache.Add(instance);
                index = PropCache.Count - 1;
            }

            var mainProp = PropCache[index];
            mainProp.Active();
        }
    }
}