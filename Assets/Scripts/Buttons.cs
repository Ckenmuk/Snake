using UnityEngine;

namespace Snake
{
    public class Buttons : MonoBehaviour
    {
        [SerializeField] public GameObject snake;
        [SerializeField] public GameObject button;
        [SerializeField] public GameObject gameOver;
        public bool isOnGame;

        private void Start()
        {
            gameOver.SetActive(false);
        }
        private void Update()
        {
            isOnGame = snake.GetComponent<Snake>().isOnGame;
            if (isOnGame) { button.SetActive(false); } else button.SetActive(true);
        }

        public void OnClickResume()
        {
            if (snake.GetComponent<Transform>().position != Vector3.zero)
            {
                isOnGame = !isOnGame;
                snake.GetComponent<Snake>().isOnGame = isOnGame;
            }

        }
        public void OnClickNewGame()
        {
            snake.GetComponent<Snake>().ResetState();
            isOnGame = !isOnGame;
            snake.GetComponent<Snake>().isOnGame = isOnGame;
            gameOver.SetActive(false);
        }

    }
}