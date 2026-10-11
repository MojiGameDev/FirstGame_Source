namespace __SARV.Common.Base
{
    public abstract class SVSingletonGlobalMonoBehaviour<T> : SVSingleton<T> where T : SVOverrideMonoBehaviour
    {
        protected sealed override bool IsPersistent => true;
    }
}