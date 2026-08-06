using UnityEngine;

namespace __MD.Script.Core.Base
{
    public abstract class MDSingleton<T> : MDOverrideMonoBehaviour where T : MDMonoBehaviour
    {
        private static T _instance;
        private static bool _isQuitting;

        public static T Instance => IsAvailable ? _instance : null;
        public static bool IsAvailable => !_isQuitting && _instance != null;
        public static bool Exists => _instance != null;

        protected abstract bool IsPersistent { get; }

        protected override void Awake()
        {
            base.Awake();
            if (_instance == null)
            {
                _instance = this as T;

                if (IsPersistent && Application.isPlaying)
                    DontDestroyOnLoad(gameObject);

                OnSingletonInitialized();
                return;
            }

            if (_instance == this)
                return;

            Debug.LogError(
                $"Duplicate {typeof(T).Name} detected on '{name}'. Destroying duplicate.",
                gameObject);

            if (Application.isPlaying)
            {
                Destroy(gameObject);
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (_instance == this)
            {
                _instance = null;
            }
        }

        protected virtual void OnApplicationQuit()
        {
            _isQuitting = true;
        }

        protected virtual void OnSingletonInitialized()
        {
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics()
        {
            _instance = null;
            _isQuitting = false;
        }
    }
}