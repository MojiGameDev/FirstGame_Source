using UnityEngine;

namespace __SARV.Framework.Module.Cameras.Entity
{
    public class SVActiveShakePower
    {
        public SVShakePower ShakePower { get; set; }

        public float Elapsed { get; set; }

        public float Seed { get; set; }

        public static SVActiveShakePower Create(SVShakePower shakePower)
        {
            return new SVActiveShakePower
            {
                ShakePower = shakePower,
                Elapsed = 0,
                Seed = Random.Range(0f, 1000f)
            };
        }
    }
}