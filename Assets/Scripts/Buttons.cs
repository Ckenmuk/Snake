using UnityEngine;

namespace Snake
{
    public class Buttons : MonoBehaviour
    {
        [SerializeField] public GameObject snake;
        [SerializeField] public GameObject button;
        public bool isOnGame;

        private void Update()
        {
            isOnGame = snake.GetComponent<Snake>().isOnGame;
            if (isOnGame) { button.SetActive(false); } else button.SetActive(true);
        }

        public void OnClickResume()
        {
            isOnGame = !isOnGame;
            snake.GetComponent<Snake>().isOnGame = isOnGame;
        }
        public void OnClickNewGame()
        {
            snake.GetComponent<Snake>().ResetState();

            isOnGame = !isOnGame;
            snake.GetComponent<Snake>().isOnGame = isOnGame;
        }

    }
}