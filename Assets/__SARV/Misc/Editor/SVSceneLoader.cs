using UnityEditor;
using UnityEditor.SceneManagement;

namespace __SARV.Misc.Editor
{
    public static class SVSceneLoader
    {
        private const string CINEMATIC_SCENE = @"Assets\__Content\Scene\Cinematic\";
        private const string DEMO_SCENE = @"Assets\__Content\Scene\Demo\";
        private const string PLAY_SCENE = @"Assets\__Content\Scene\Play\";
        private const string MENU_SCENE = @"Assets\__Content\Scene\Menu\";
        private const string ACT_01_SECTION_01 = @"Assets\__Content\Scene\Landscape\Act_01\Section_01\";
        private const string ACT_01_SECTION_02 = @"Assets\__Content\Scene\Landscape\Act_01\Section_02\";
        private const string ACT_01_SECTION_03 = @"Assets\__Content\Scene\Landscape\Act_01\Section_03\";

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

        [MenuItem("SARV/Scene/Act01_Section03")]
        public static void LoadAct01Section03()
        {
            // Close all current scenes first
            CloseAllScenes();

            EditorSceneManager.OpenScene($"{ACT_01_SECTION_03}Act_01_Section_03.unity", OpenSceneMode.Single);
        }

        [MenuItem("SARV/Scene/Demo_Character")]
        public static void DemoCharacter()
        {
            // Close all current scenes first
            CloseAllScenes();

            EditorSceneManager.OpenScene($"{DEMO_SCENE}Demo_Character.unity", OpenSceneMode.Single);
        }

        [MenuItem("SARV/Scene/Cinematic_01")]
        public static void Cinematic_01()
        {
            // Close all current scenes first
            CloseAllScenes();
            
            EditorSceneManager.OpenScene($"{PLAY_SCENE}Game.unity", OpenSceneMode.Single);
            EditorSceneManager.OpenScene($"{PLAY_SCENE}Controller.unity", OpenSceneMode.Additive);
            EditorSceneManager.OpenScene($"{CINEMATIC_SCENE}Cinematic_01.unity", OpenSceneMode.Additive);
            EditorSceneManager.OpenScene($"{CINEMATIC_SCENE}Cinematic_Landscape.unity", OpenSceneMode.Additive);
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