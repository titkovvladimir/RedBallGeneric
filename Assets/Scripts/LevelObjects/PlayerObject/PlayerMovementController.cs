using UnityEngine;

namespace LevelObjects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float airControlSpeed = 2f; // Сила управления в воздухе
        [SerializeField] private float maxMoveSpeed = 8f; // Максимальная горизонтальная скорость
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float rotationSpeed = 200f; // Скорость вращения при движении
        [SerializeField] private float groundCheckRadius = 0.5f;
        [SerializeField] private float groundCheckPointDelta = 0.1f;
        [SerializeField] private LayerMask groundLayer; // Для проверки земли

        private Rigidbody2D _rigidbody2D;
        private bool _isGrounded;
        private float _horizontalInput;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            _horizontalInput = Core.InputManager.Instance.GetHorizontalInput();

            if (Core.InputManager.Instance.GetJumpInput() && _isGrounded)
            {
                Jump();
            }

            RotatePlayer();
        }
        
        private void RotatePlayer()
        {
            if (!_isGrounded) return; // Только вращаемся, когда на земле

            float horizontalVelocity = _rigidbody2D.velocity.x;
            float rotationAmount = -horizontalVelocity * rotationSpeed * Time.deltaTime;

            transform.Rotate(0, 0, rotationAmount);
        }

        private void FixedUpdate()
        {
            Move();
            LimitSpeed();
            CheckGrounded();
        }

        private void Move()
        {
            float moveForce = _isGrounded ? moveSpeed : airControlSpeed;

            if (Mathf.Abs(_horizontalInput) > 0.01f)
            {
                Vector2 force = new Vector2(_horizontalInput * moveForce, 0);
                _rigidbody2D.AddForce(force, ForceMode2D.Force);
            }
        }
        
        private void LimitSpeed()
        {
            Vector2 velocity = _rigidbody2D.velocity;

            if (Mathf.Abs(velocity.x) > maxMoveSpeed)
            {
                velocity.x = Mathf.Sign(velocity.x) * maxMoveSpeed;
                _rigidbody2D.velocity = velocity;
            }
        }

        private void Jump()
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void CheckGrounded()
        {
            Vector2 position = transform.position;
            _isGrounded = Physics2D.OverlapCircle(position + Vector2.down * groundCheckPointDelta, groundCheckRadius, groundLayer);
        }

        private void OnDrawGizmosSelected()
        {
            // Отладочный вывод
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position + Vector3.down * groundCheckPointDelta, groundCheckRadius);
        }
    }
}