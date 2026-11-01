using __SARV.Framework.Module.Actor.SubCharacter;
using UnityEngine;

namespace __SARV.Framework.Module.Actor
{
    public abstract class SVActor : SVSubActorGeneral
    {
        public Vector3 Position => transform.position;
        public Vector3 Forward => transform.forward;
    }
}