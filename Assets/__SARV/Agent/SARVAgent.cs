using __SARV.Core.Base;

namespace __SARV.Agent
{
    public class SARVAgent : SVCharacter
    {
        protected override void Awake()
        {
            SetArgument(this);
            base.Awake();
        }
    }
}