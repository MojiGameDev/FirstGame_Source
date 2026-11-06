using System;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.Entity
{
    public readonly struct SVEquipmentKey : IEquatable<SVEquipmentKey>
    {
        public readonly GameObject Model;
        public readonly Transform Bone;

        public SVEquipmentKey(GameObject model, Transform bone)
        {
            Model = model;
            Bone = bone;
        }

        public bool Equals(SVEquipmentKey other)
        {
            return Model == other.Model && Bone == other.Bone;
        }

        public override bool Equals(object obj)
        {
            return obj is SVEquipmentKey other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                Model,
                Bone != null ? Bone.GetInstanceID() : 0
            );
        }
    }
}