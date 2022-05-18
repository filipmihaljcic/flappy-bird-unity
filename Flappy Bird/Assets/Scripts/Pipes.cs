using UnityEngine;

namespace Project.Scripts
{
    public class Pipes : MonoBehaviour
    {
        public Transform _top;
        public Transform _bottom;

        [Tooltip("Speed in which our world moves.")] public float _speed = 5f;
        private float _leftEdge;

        private void Start()
        {
            // calculate our left edge position 
            _leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        }

        private void Update()
        {
            // moves our pipes to the left side of the screen 
            transform.position += Vector3.left * _speed * Time.deltaTime;

            // if pipes position passed left edge
            if (transform.position.x < _leftEdge) 
                Destroy(gameObject);
        }
    }
}
