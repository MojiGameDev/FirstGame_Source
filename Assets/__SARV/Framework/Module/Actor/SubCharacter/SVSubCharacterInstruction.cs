using System;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Interactor;
using __SARV.Framework.Module.Melee;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubCharacter
{
    [Serializable]
    public abstract class SVSubCharacterActor : SVSubCharacterCombat
    {
        public void SetInteractor(SARVInteractor interactor)
        {
            CurrentInteractor = interactor;
        }

        public void AttachProp(Animator animator, GameObject prop, SVBone bone, Vector3 position, Vector3 rotation)
        {
            var index = PropCache.IndexOf(prop);
            if (index == -1)
            {
                var boneTransform = bone.GetTransform(animator);
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