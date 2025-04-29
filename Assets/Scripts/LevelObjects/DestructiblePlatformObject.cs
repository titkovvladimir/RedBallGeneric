using UnityEngine;

namespace LevelObjects
{
    /// <summary>
    /// Платформа, которая разрушается после контакта с игроком.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class DestructiblePlatformObject : LevelObject
    {
        [SerializeField] private float destroyDelay = 0.5f; // Задержка перед разрушением

        private bool _isTriggered = false;

        protected override void Awake()
        {
            var collider = GetComponent<Collider2D>();
            collider.isTrigger = false; // Чтобы платформа не мешала движению игрока при разрушении
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_isTriggered)
                return;

            if (collision.gameObject.CompareTag("Player"))
            {
                _isTriggered = true;
                StartCoroutine(DestroyPlatformCoroutine());
            }
        }

        private System.Collections.IEnumerator DestroyPlatformCoroutine()
        {
            yield return new WaitForSeconds(destroyDelay);

            // Здесь можно добавить анимацию разрушения или звуки

            Destroy(gameObject);
        }
    }
}