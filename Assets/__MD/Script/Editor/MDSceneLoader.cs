using UnityEditor;
using UnityEditor.SceneManagement;

namespace __MD.Script.Editor
{
    public static class MDSceneLoader
    {
        private const string DEMO_SCENE = @"Assets\__MD\Scene\Demo\";
        private const string GAMEPLAY_SCENE = @"Assets\__MD\Scene\Gameplay\";
        private const string MENU_SCENE = @"Assets\__MD\Scene\Menu\";
        private const string ACT_01_SECTION_01 = @"Assets\__MD\Scene\World\Act_01\Section_01\";
        private const string ACT_01_SECTION_02 = @"Assets\__MD\Scene\World\Act_01\Section_02\";

        [MenuItem("MD/Scene/Gameplay")]
        public static void LoadGameplay()
        {
            // Close all current scenes first
            CloseAllScenes();

            EditorSceneManager.OpenScene($"{GAMEPLAY_SCENE}Gameplay.unity", OpenSceneMode.Single);
            EditorSceneManager.OpenScene($"{DEMO_SCENE}Demo_Gameplay.unity", OpenSceneMode.Additive);
        }

        [MenuItem("MD/Scene/MainMenu")]
        public static void LoadMainMenu()
        {
            // Close all current scenes first
            CloseAllScenes();

            EditorSceneManager.OpenScene($"{MENU_SCENE}Menu_Main.unity", OpenSceneMode.Single);
        }

        [MenuItem("MD/Scene/Act01_Section01")]
        public static void LoadAct01Section01()
        {
            // Close all current scenes first
            CloseAllScenes();

            EditorSceneManager.OpenScene($"{ACT_01_SECTION_01}Act_01_Section_01.unity", OpenSceneMode.Single);
        }

        [MenuItem("MD/Scene/Act01_Section02")]
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