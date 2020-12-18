using Game.Player;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody = default;
        [SerializeField] private float _jumpRaycastDistance = 0.1f;
        [SerializeField] private float _increaseAcceleration = 10.0f;
        [SerializeField] private float _decreaseAcceleration = 30.0f;
        [SerializeField] private float _maxVelocity = 15.0f;
        [SerializeField] private float _jumpHeight = 1.0f;
        [SerializeField] private GameObject _projectilePrefab = default;
        [SerializeField] private Transform _projectileSpawnPlaceholder = default;
        [SerializeField] private float _projectileInitialSpeed = 200.0f;
        [SerializeField] private Animator _animator = default;
        [SerializeField] private SpriteRenderer _playerCircle = default;
        
        
        public PlayerModel PlayerModel;
        private IPlayerTypeStrategy _strategy;

        private Controls _controls;

        private Vector2 _movementDirection;
        private Vector2 _rotationDirection;

        private void Awake()
        {
            _controls = new Controls();
            _controls.Player.Jump.started += context => Jump();
            _controls.Player.Move.performed += context => _movementDirection = context.ReadValue<Vector2>();
            _controls.Player.Move.canceled += context => _movementDirection = Vector2.zero;
            _controls.Player.Rotate.performed += context => _rotationDirection = context.ReadValue<Vector2>();
            _controls.Player.Rotate.canceled += context => _rotationDirection = Vector2.zero;
            _controls.Player.Shoot.performed += context => Shoot();
            _controls.Player.Ability.performed += context => UseAbility();
        }

        public void Initialize(string playerName, Color color)
        {
            PlayerModel = new PlayerModel(playerName);
            PlayerModel.OnImmuneStatusChanged += OnImmuneStatusChanged;
            _playerCircle.color = color;
        }

        public void SetStrategy(IPlayerTypeStrategy strategy)
        {
            _strategy = strategy;
        }

        private void OnImmuneStatusChanged()
        {
            _animator.SetBool("IsImmune", PlayerModel.IsImmune);
        }

        private void Shoot()
        {
            var projectileGO = Instantiate(_projectilePrefab);
            var projectileController = projectileGO.GetComponent<ProjectileController>();
            projectileController.Initialize(_projectileSpawnPlaceholder.position, transform.forward,
                _projectileInitialSpeed);
        }

        private void UseAbility()
        {
            _strategy.UseAbility();
        }
        
        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void FixedUpdate()
        {
            var horizontalVelocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.z) +
                                     _movementDirection * (_increaseAcceleration * Time.fixedDeltaTime);
            horizontalVelocity = Vector2.ClampMagnitude(horizontalVelocity, _maxVelocity);

            if (_movementDirection == Vector2.zero)
            {
                if (horizontalVelocity.magnitude < _decreaseAcceleration * Time.fixedDeltaTime)
                {
                    horizontalVelocity = Vector2.zero;
                }
                else
                {
                    horizontalVelocity = horizontalVelocity -
                                         horizontalVelocity.normalized * (_decreaseAcceleration * Time.fixedDeltaTime);
                }
            }

            _rigidbody.velocity = new Vector3(horizontalVelocity.x, _rigidbody.velocity.y, horizontalVelocity.y);

            transform.LookAt(transform.position + new Vector3(_rotationDirection.x, 0.0f, _rotationDirection.y));

            var deltaTime = Time.fixedDeltaTime;

            PlayerModel.Tick(deltaTime);
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position + 0.1f * Vector3.up, -Vector3.up, _jumpRaycastDistance);
        }

        private void Jump()
        {
            if (IsGrounded())
            {
                _rigidbody.velocity += Vector3.up * _rigidbody.mass *
                                       Mathf.Sqrt(2 * Physics.gravity.magnitude * _jumpHeight);
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.GetComponent<EnemyController>() != null)
            {
                const float damage = 20f;
                PlayerModel.ReceiveDamage(damage);
            }
        }
    }
}