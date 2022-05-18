using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [Header("Game Settings")]
        [Tooltip("UI score element itself.")] public Text _scoreText;
        [Tooltip("UI play button itself.")] public GameObject _playButton;
        [Tooltip("UI game over image.")] public GameObject _gameOver;
        public int _score { get; private set; }

        private Player _player;
        private Spawner _spawner;
        public static AudioSource[] _sfx;

        private void Awake()
        {
            Application.targetFrameRate = 60;

            _player = FindObjectOfType<Player>();
            _spawner = FindObjectOfType<Spawner>();
            _sfx = GameObject.FindWithTag("Game Manager").GetComponentsInChildren<AudioSource>();

            Pause();
        }

        public void Play()
        {
            _score = 0;
            _scoreText.text = _score.ToString();

            _playButton.SetActive(false);
            _gameOver.SetActive(false);

            Time.timeScale = 1f;
            _player.enabled = true;

            Pipes[] pipes = FindObjectsOfType<Pipes>();

            for (int i = 0; i < pipes.Length; i++) 
                Destroy(pipes[i].gameObject);
        }

        public void GameOver()
        {
            _playButton.SetActive(true);
            _gameOver.SetActive(true);
            // play game over sound 
            _sfx[1].Play();

            Pause();
        }

        public void Pause()
        {
            Time.timeScale = 0f;
            _player.enabled = false;
        }

        public void IncreaseScore()
        {
            _score++;
            // play increase score sound 
            _sfx[0].Play();
            _scoreText.text = _score.ToString();
        }
    }
}
