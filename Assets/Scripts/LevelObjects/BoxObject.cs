using UnityEngine;

namespace LevelObjects
{
    /// <summary>
    /// Простая физическая коробка, которую можно толкать.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class BoxObject : LevelObject
    {
        protected override void Awake()
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic; // Коробка реагирует на физику
        }
    }
}