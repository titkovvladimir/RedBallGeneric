using UnityEngine;

namespace LevelObjects
{
    /// <summary>
    /// Базовый класс для всех объектов уровня.
    /// </summary>
    public class LevelObject : MonoBehaviour
    {
        protected virtual void Awake()
        {
            // Базовая инициализация для всех LevelObject
        }

        protected virtual void Start()
        {
            // Базовая логика старта
        }

        protected virtual void Update()
        {
            // Базовая логика обновления
        }
    }
}