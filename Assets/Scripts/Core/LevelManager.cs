using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    /// <summary>
    /// Управляет загрузкой и перезагрузкой уровней.
    /// Позволяет переходить к следующему уровню.
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }
        
        private const string MainMenuSceneName = "MainScene";

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Перезагружает текущую активную сцену.
        /// </summary>
        public void ReloadCurrentLevel()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
        
        /// <summary>
        /// Загружает сцену по индексу в Build Settings.
        /// </summary>
        public void LoadLevelByIndex(int index)
        {
            if (index >= 0 && index < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(index);
            }
            else
            {
                Debug.LogError($"Attempt to load a scene with an incorrect index: {index}");
            }
        }

        /// <summary>
        /// Загружает сцену главного меню (если нужно).
        /// </summary>
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(MainMenuSceneName);
        }
        
        public void CompleteLevel()
        {
            Debug.Log("Level Completed! Trying to load next level...");
            
            Core.GameManager.Instance.CompleteLevel();

            if (Core.GameManager.Instance.GetLevelsCompletedNumber()+1 < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
            {
                Core.GameManager.Instance.StartNewLevel();
            }
            else
            {
                Debug.Log("All levels completed! Returning to Main Menu...");
                Core.GameManager.Instance.ResetProfile();
                LoadMainMenu();
            }
        }
    }
}