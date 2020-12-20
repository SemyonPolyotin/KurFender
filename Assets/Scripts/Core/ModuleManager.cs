using UnityEngine.SceneManagement;

namespace Core
{
    public static class ModuleManager
    {
        public static void LoadMainMenu()
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }

        public static void LoadGame(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}