using UnityEngine;

namespace __MD.Script.Core.Util
{
    public static class MDSpawnerUtil
    {
        /// <summary>
        /// Instantiates a prefab as a child of a parent transform at specific local position and rotation
        /// </summary>
        public static GameObject InstantiateAsChild(GameObject prefab, Transform parent, Vector3 localPosition, Quaternion localRotation)
        {
            if (prefab == null)
            {
                Debug.LogError("MDSpawnerUtil: Prefab is null!");
                return null;
            }

            if (parent == null)
            {
                Debug.LogError("MDSpawnerUtil: parent is null!");
                return null;
            }

            var instance = Object.Instantiate(prefab, parent);
            instance.transform.localPosition = localPosition;
            instance.transform.localRotation = localRotation;

            return instance;
        }

        /// <summary>
        /// Instantiates a prefab
        /// </summary>
        public static GameObject Instantiate(GameObject prefab)
        {
            if (prefab == null)
            {
                Debug.LogError("MDSpawnerUtil: Prefab is null!");
                return null;
            }

            var instance = Object.Instantiate(prefab);
            instance.transform.position = Vector3.zero;
            instance.transform.rotation = Quaternion.identity;

            return instance;
        }
    }
}