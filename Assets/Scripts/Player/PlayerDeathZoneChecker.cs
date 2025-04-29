using UnityEngine;
using Core; // Чтобы использовать LevelManager для перезапуска

namespace Core
{
    public class PlayerDeathZoneChecker : MonoBehaviour
    {
        [SerializeField] private float deathYThreshold = -10f; // Высота, ниже которой считаем смерть

        private void Update()
        {
            if (transform.position.y < deathYThreshold)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Player fell into the void. Reloading level...");
            LevelManager.Instance.ReloadCurrentLevel();
        }
    }
}