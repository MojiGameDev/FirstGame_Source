using System.Collections.Generic;
using __SARV.Framework.Integration.PoolKit.Wrapper;
using __SARV.Framework.Module.Identifier;
using DarkTonic.PoolBoss;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.SceneControl.Game.SubGame
{
    public abstract class SVSubGamePool : SVSubGameInput
    {
        [FoldoutGroup("Pool")] [SerializeField] [TableList]
        private List<SVWrapperPoolKitIdentifier> wrappers = new();

        private readonly Dictionary<SARVIdentifier, Transform> RuntimePoolTransform = new();

        protected override void Awake()
        {
            base.Awake();
            HandleWrappersToDictionary();
        }

        public Transform SpawnInPool(SARVIdentifier identifier, Vector3 position)
        {
            return SpawnInPool(identifier, position, Quaternion.identity);
        }

        public Transform SpawnInPool(SARVIdentifier identifier, Vector3 position, Quaternion rotation)
        {
            return PoolBoss.SpawnInPool(RuntimePoolTransform[identifier], position, rotation);
        }

        public Transform SpawnOutsidePool(SARVIdentifier identifier, Vector3 position)
        {
            return SpawnOutsidePool(identifier, position, Quaternion.identity);
        }

        public Transform SpawnOutsidePool(SARVIdentifier identifier, Vector3 position, Quaternion rotation)
        {
            return PoolBoss.SpawnOutsidePool(RuntimePoolTransform[identifier], position, rotation);
        }

        public void Despawn(SARVIdentifier identifier)
        {
            PoolBoss.Despawn(RuntimePoolTransform[identifier]);
        }

        private void HandleWrappersToDictionary()
        {
            foreach (var wrapper in wrappers)
            {
                RuntimePoolTransform.Add(wrapper.Identifier, wrapper.Target);
            }
        }
    }
}