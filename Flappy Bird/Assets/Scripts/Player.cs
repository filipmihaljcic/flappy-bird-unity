using UnityEngine;

namespace Project.Scripts
{
    public class Player : MonoBehaviour
    {
        [Header("Player Settings")]

        [Tooltip("Strength of player jump.")] public float _strength = 5f;
        [Tooltip("Gravity intensity.")] public float _gravity = -9.81f;
        [Tooltip("How much bird tilts when jumping.")] public float _tilt = 5f;


        [Tooltip("Array of animation sprites.")] public Sprite[] _sprites;
        private SpriteRenderer _spriteRenderer;
        private int _spriteIndex;

        private Vector3 _direction;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        }

        private void OnEnable()
        {
            // reset position of bird 
            Vector3 _position = transform.position;
            _position.y = 0f;
            transform.position = _position;
            _direction = Vector3.zero;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
                _direction = Vector3.up * _strength;

            // Apply gravity and update the position
            _direction.y += _gravity * Time.deltaTime;
            transform.position += _direction * Time.deltaTime;

            // Tilt the bird based on the direction
            Vector3 _rotation = transform.eulerAngles;
            _rotation.z = _direction.y * _tilt;
            transform.eulerAngles = _rotation;
        }

        private void AnimateSprite()
        {
            _spriteIndex++;

            if (_spriteIndex >= _sprites.Length) 
                _spriteIndex = 0;

            if (_spriteIndex < _sprites.Length && _spriteIndex >= 0) 
               _spriteRenderer.sprite = _sprites[_spriteIndex];
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Obstacle")) 
                FindObjectOfType<GameManager>().GameOver();

            else if (other.gameObject.CompareTag("Scoring")) 
                FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
