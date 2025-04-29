using UnityEngine;

namespace LevelObjects
{
    /// <summary>
    /// Управляет логикой игрока на уровне.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerObject : LevelObject
    {
        private Rigidbody2D _rigidbody2D;

        protected override void Awake()
        {
            base.Awake();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected override void Update()
        {
            base.Update();
            // Пока пусто — сюда позже добавим движение и прыжок
        }
    }
}