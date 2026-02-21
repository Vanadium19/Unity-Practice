using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIModule
{
    public class Menu
    {
        private const string GameScene = "Game";
        private const string MainMenu = "MainMenu";

        public void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        public void LoadGame() => SceneManager.LoadScene(GameScene);

        public void ReturnToMenu() => SceneManager.LoadScene(MainMenu);

        public void Restart()
        {
            var currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }
}