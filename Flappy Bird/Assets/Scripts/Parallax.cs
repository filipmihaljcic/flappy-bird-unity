using UnityEngine;

namespace Project.Scripts
{
    public class Parallax : MonoBehaviour
    {
        [Tooltip("Moving speed of our background.")] public float _animationSpeed = 1f;

        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            // this will offset our main background texture and create "parallax effect" 
            _meshRenderer.material.mainTextureOffset += new Vector2(_animationSpeed * Time.deltaTime, 0);
        }
    }
}
