using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUIManager : MonoBehaviour
    {
        [SerializeField] private Button startLevelButton;

        private void Awake()
        {
            if (startLevelButton != null)
            {
                startLevelButton.onClick.AddListener(OnStartLevelClicked);
            }
            else
            {
                Debug.LogWarning("Start Level Button is not assigned!");
            }
        }

        private void OnStartLevelClicked()
        {
            Core.GameManager.Instance.StartNewLevel();
        }
        
        public void StartGame()
        {
            Core.GameManager.Instance.StartNewLevel();
        }
    }
}