using __SARV.Common.Base;
using __SARV.Framework.Module.Subtitle.SVSubSubtitle;
using Sirenix.OdinInspector;

namespace __SARV.Framework.Module.Subtitle
{
    public class SARVSubtitle : SVSubSubtitleManager
    {
        [Button]
        public void ShowSubtitle1()
        {
            SARVSubtitle.Instance.ShowSubtitle("The path ahead is dangerous.");
        }

        [Button]
        public void ShowSubtitle2()
        {
            SARVSubtitle.Instance.ShowSubtitle("We should keep moving.");
        }

        [Button]
        public void ShowSubtitle3()
        {
            SARVSubtitle.Instance.ShowSubtitle("Wait. Did you hear that?");
        }
    }
}