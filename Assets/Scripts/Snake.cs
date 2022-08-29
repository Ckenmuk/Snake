using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class Snake : MonoBehaviour
    {
        [SerializeField] private Transform segmentPrefab;
        [SerializeField] private int initialSize = 4;
        [SerializeField] private GameObject buttonResume;
        [SerializeField] private GameObject buttonNewGame;
        
        private Vector2 _direction = Vector2.right;
        private List<Transform> _segments = new List<Transform>();

        public bool isOnGame;
        public int score;

        private void Start()
        {
            isOnGame = false;
            ResetState();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                _direction = Vector2.down;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _direction = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _direction = Vector2.left;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isOnGame = !isOnGame;
                buttonResume.SetActive(!isOnGame);
                buttonNewGame.SetActive(!isOnGame);
            }
        }

        private void FixedUpdate()
        {
            if (isOnGame)
            {
                for (int i = _segments.Count - 1; i > 0; i--)
                {
                    _segments[i].position = _segments[i - 1].position;
                }

                transform.position = new Vector3(
                    Mathf.Round(transform.position.x) + _direction.x,
                    Mathf.Round(transform.position.y) + _direction.y,
                    0.0f
                    );
            }
        }

        private void Grow()
        {
            Transform segment = Instantiate(segmentPrefab);
            segment.position = _segments[_segments.Count - 1].position;
            _segments.Add(segment);
            score++;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Apple")
            {
                Grow();
            }
            else if (other.tag == "Obstacle")
            {
                ResetState();
            }
        }

        public void ResetState()
        {
            for (int i = 1; i < _segments.Count; i++)
            {
                Destroy(_segments[i].gameObject);
            }

            _segments.Clear();
            _segments.Add(transform);

            transform.position = Vector3.zero;

            for (int i = 1; i < initialSize; i++)
            {
                _segments.Add(Instantiate(segmentPrefab));
            }
            score = 0;
        }
    }
}