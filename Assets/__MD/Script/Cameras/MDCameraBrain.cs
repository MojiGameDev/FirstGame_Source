using __MD.Script.Cameras.SubCameraBrain;
using __MD.Script.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.Cameras
{
    public class MDCameraBrain : MDSubCameraBrainShake
    {
        [FoldoutGroup("Test")] [SerializeField]
        private MDIdentifier testIdentifier;

        [FoldoutGroup("Test")]
        [Button("TestShake")]
        private void TestShake()
        {
            Shake(testIdentifier);
        }
    }
}