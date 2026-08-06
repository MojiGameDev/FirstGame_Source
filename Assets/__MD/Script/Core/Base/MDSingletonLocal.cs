namespace __MD.Script.Core.Base
{
    public abstract class MDSingletonLocal<T> : MDSingleton<T> where T : MDMonoBehaviour
    {
        protected sealed override bool IsPersistent => false;
    }
}