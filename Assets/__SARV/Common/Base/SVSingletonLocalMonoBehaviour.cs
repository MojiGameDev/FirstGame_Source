namespace __SARV.Common.Base
{
    public abstract class SVSingletonLocalMonoBehaviour<T> : SVSingleton<T> where T : SVOverrideMonoBehaviour
    {
        protected sealed override bool IsPersistent => false;
    }
}