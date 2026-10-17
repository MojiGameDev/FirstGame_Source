using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;

namespace __SARV.Framework.Common.Base
{
    public abstract class SVActor : SVOverrideMonoBehaviour
    {
        public virtual void ChangeBehaviorTo(SARVIdentifier stateIdentifier)
        {
        }
    }
}