namespace __MD.Script.Core.Base
{
    public abstract class MDSingletonGlobal<T> : MDSingleton<T> where T : MDMonoBehaviour
    {
        protected sealed override bool IsPersistent => true;
    }
}