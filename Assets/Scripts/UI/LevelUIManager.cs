using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelUIManager : MonoBehaviour
    {
        [SerializeField] private Button repeatLevelButton;
        [SerializeField] private Button exitLevelButton;

        private void Awake()
        {
            if (repeatLevelButton != null)
                repeatLevelButton.onClick.AddListener(OnRepeatLevelClicked);
            else
                Debug.LogWarning("Repeat Level Button is not assigned!");

            if (exitLevelButton != null)
                exitLevelButton.onClick.AddListener(OnExitLevelClicked);
            else
                Debug.LogWarning("Exit Level Button is not assigned!");
        }

        private void OnRepeatLevelClicked()
        {
            Core.LevelManager.Instance.ReloadCurrentLevel();
        }

        private void OnExitLevelClicked()
        {
            Core.LevelManager.Instance.LoadMainMenu();
        }
    }
}