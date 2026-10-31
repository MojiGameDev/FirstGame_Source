using System;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Common.Entity
{
    [Serializable]
    public struct SVBone
    {
        [SerializeField] private SVBoneType boneType;

        [SerializeField] [ShowIf(nameof(IsBoneTypeHuman))]
        private HumanBodyBones human;

        [SerializeField] [HideIf(nameof(IsBoneTypeHuman))]
        private string path;

        public bool IsBoneTypeHuman => boneType == SVBoneType.Human;

        public SVBone(HumanBodyBones humanBone)
        {
            boneType = SVBoneType.Human;
            human = humanBone;
            path = string.Empty;
        }

        public SVBone(string bonePath)
        {
            boneType = SVBoneType.Path;
            human = HumanBodyBones.Hips;
            path = bonePath;
        }

        public Transform GetTransform(Animator animator)
        {
            return this.boneType switch
            {
                SVBoneType.Human => animator.GetBoneTransform(this.human),
                SVBoneType.Path => animator.transform.Find(this.path),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public override string ToString()
        {
            return this.boneType switch
            {
                SVBoneType.Human => human.ToReadableString(),
                SVBoneType.Path => this.path,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}