using __SARV.Cameras.SubCamera;
using __SARV.Core.Access;

namespace __SARV.Cameras
{
    public class SARVCamera : SubSARVCameraReference
    {
        protected override void Awake()
        {
            SVAccessCamera.Initial(this);
            base.Awake();
        }
    }
}