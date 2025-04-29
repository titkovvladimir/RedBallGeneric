using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public PlayerProfile PlayerProfile { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                
                Initialize();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Initialize()
        {
            // Создание профиля игрока
            PlayerProfile = new PlayerProfile();
        }

        public void StartNewLevel()
        {
            Core.LevelManager.Instance.LoadLevelByIndex(PlayerProfile.LevelsCompleted+1);
        }

        public int GetLevelsCompletedNumber()
        {
            return PlayerProfile.LevelsCompleted;
        }

        /// <summary>
        /// Вызывается, когда игрок завершает уровень успешно.
        /// </summary>
        public void CompleteLevel()
        {
            PlayerProfile.CompleteLevel();
            Debug.Log($"Level completed! Total completed levels: {PlayerProfile.LevelsCompleted}");
        }

        /// <summary>
        /// Метод для сброса данных игрока (например, при старте новой игры).
        /// </summary>
        public void ResetProfile()
        {
            PlayerProfile = new PlayerProfile();
            Debug.Log("Player profile has been reset.");
        }
    }
}