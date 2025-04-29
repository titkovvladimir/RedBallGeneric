using UnityEngine;
using Core;

namespace LevelObjects
{
    /// <summary>
    /// Чекпоинт окончания уровня. Завершает уровень при пересечении с игроком.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class LevelFinishCheckPointObject : LevelObject
    {
        protected override void Awake()
        {
            // Убеждаемся, что Collider2D работает как триггер
            var collider = GetComponent<Collider2D>();
            collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player reached finish checkpoint!");
                LevelManager.Instance.CompleteLevel();
            }
        }
    }
}