using UnityEditor;
using UnityEditor.SceneManagement;

namespace __SARV.Editor
{
    public static class SVSceneLoader
    {
        private const string DEMO_SCENE = @"Assets\__MD\Scene\Demo\";
        private const string PLAY_SCENE = @"Assets\__MD\Scene\Play\";
        private const string MENU_SCENE = @"Assets\__MD\Scene\Menu\";
        private const string ACT_01_SECTION_01 = @"Assets\__MD\Scene\Landscape\Act_01\Section_01\";
        private const string ACT_01_SECTION_02 = @"Assets\__MD\Scene\Landscape\Act_01\Section_02\";

        [MenuItem("SARV/Scene/Play")]
        public static void LoadPlay()
        {
            // Close all current scenes first
            CloseAllScenes();

            EditorSceneManager.OpenScene($"{PLAY_SCENE}Game.unity", OpenSceneMode.Single);
            EditorSceneManager.OpenScene($"{PLAY_SCENE}Controller.unity", OpenSceneMode.Additive);
            EditorSceneManager.OpenScene($"{DEMO_SCENE}Demo_Gameplay.unity", OpenSceneMode.Additive);
        }

        [MenuItem("SARV/Scene/MainMenu")]
        public static void LoadMainMenu()
        {
            // Close all current scenes first
            CloseAllScenes();

            EditorSceneManager.OpenScene($"{MENU_SCENE}MainMenu.unity", OpenSceneMode.Single);
        }

        [MenuItem("SARV/Scene/Act01_Section01")]
        public static void LoadAct01Section01()
        {
            // Close all current scenes first
            CloseAllScenes();

            EditorSceneManager.OpenScene($"{ACT_01_SECTION_01}Act_01_Section_01.unity", OpenSceneMode.Single);
        }

        [MenuItem("SARV/Scene/Act01_Section02")]
        public static void LoadAct01Section02()
        {
            // Close all current scenes first
            CloseAllScenes();

            EditorSceneManager.OpenScene($"{ACT_01_SECTION_02}Act_01_Section_02.unity", OpenSceneMode.Single);
        }

        private static void CloseAllScenes()
        {
            // Close all currently open scenes
            for (var i = EditorSceneManager.sceneCount - 1; i >= 0; i--)
            {
                var scene = EditorSceneManager.GetSceneAt(i);
                if (scene.isLoaded)
                {
                    EditorSceneManager.CloseScene(scene, true);
                }
            }
        }
    }
}