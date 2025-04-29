using UnityEngine;

namespace LevelObjects
{
    /// <summary>
    /// Представляет собой элемент земли/платформы уровня.
    /// </summary>
    [RequireComponent(typeof(BoxCollider2D))]
    public class GroundObject : LevelObject
    {
        protected override void Awake()
        {
            base.Awake();
            // GroundObject можно потом расширить (например, скользящая платформа)
        }
    }
}