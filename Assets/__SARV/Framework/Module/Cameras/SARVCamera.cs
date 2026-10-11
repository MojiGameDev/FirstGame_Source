using __SARV.Common.Access;
using __SARV.Framework.Module.Cameras.SubCamera;

namespace __SARV.Framework.Module.Cameras
{
    public class SARVCamera : SVSubCameraShot
    {
        protected override void Awake()
        {
            SVAccessCamera.Initial(this);
            base.Awake();
        }
    }
}