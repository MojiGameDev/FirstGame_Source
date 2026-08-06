namespace __MD.Script.Core.Base
{
    public abstract class MDSingletonLocalMonoBehaviour<T> : MDSingletonLocal<T> where T : MDMonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
        }

        protected virtual void OnEnable()
        {
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
        }

        protected virtual void FixedUpdate()
        {
        }

        protected virtual void LateUpdate()
        {
        }
        
        protected virtual void OnDisable()
        {
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected virtual void OnDrawGizmos()
        {
        }

        protected virtual void OnDrawGizmosSelected()
        {
            
        }
    }
}