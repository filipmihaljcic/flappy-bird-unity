using UnityEngine;

namespace Project.Scripts 
{
    public class Spawner : MonoBehaviour
    {
        [Header("Pipe Settings")]

        [Tooltip("Pipe object itself.")] public GameObject _prefab;
        [Tooltip("Rate at which pipes are spawning.")] public float _spawnRate = 1f;
        [Tooltip("Minimum height of pipe.")] public float _minHeight = -1f;
        [Tooltip("Maximum height of pipe.")] public float _maxHeight = 2f;

        private void OnEnable()
        {
            InvokeRepeating(nameof(Spawn), _spawnRate,_spawnRate);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(Spawn));
        }

        private void Spawn()
        {
            GameObject _pipes = Instantiate(_prefab, transform.position, Quaternion.identity);
            // set random position of pipes on y axis using min and max height 
            _pipes.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
        }
    }
}
