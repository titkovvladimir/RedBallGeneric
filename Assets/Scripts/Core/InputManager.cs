using UnityEngine;

namespace Core
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        private float _uiHorizontalInput = 0f;
        private float _keyboardHorizontalInput = 0f;
        private bool _jumpPressed = false;

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

        private void Update()
        {
            // Считываем нажатия с клавиатуры для тестов на ПК
            _keyboardHorizontalInput = UnityEngine.Input.GetAxisRaw("Horizontal");

            if (UnityEngine.Input.GetButtonDown("Jump"))
            {
                _jumpPressed = true;
            }
        }

        public float GetHorizontalInput()
        {
            float combinedInput = _uiHorizontalInput + _keyboardHorizontalInput;
            return Mathf.Clamp(combinedInput, -1f, 1f); // Ограничиваем итоговое значение в диапазоне [-1, 1]
        }

        public bool GetJumpInput()
        {
            if (_jumpPressed)
            {
                _jumpPressed = false;
                return true;
            }
            return false;
        }

        // Эти методы будут вызываться кнопками UI
        public void OnMoveLeftPressed() => _uiHorizontalInput = -1;
        public void OnMoveRightPressed() => _uiHorizontalInput = 1;
        public void OnMoveReleased() => _uiHorizontalInput = 0;
        public void OnJumpPressed() => _jumpPressed = true;
    }
}