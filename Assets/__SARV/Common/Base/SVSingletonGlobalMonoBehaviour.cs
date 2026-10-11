namespace __SARV.Core.Base
{
    public abstract class SVSingletonGlobalMonoBehaviour<T> : SVSingleton<T> where T : SVOverrideMonoBehaviour
    {
        protected sealed override bool IsPersistent => true;
    }
}