using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    public class ScoreManager : MonoBehaviour
    {
        private TMP_Text scoreText;
        public int score;
        public int bestScore;
        [SerializeField] public GameObject snake;

        private void Start()
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
        }

        private void FixedUpdate()
        {
            Score();
        }

        public void Score()
        {
            score = snake.GetComponent<Snake>().score;
            scoreText = GetComponent<TMP_Text>();
            if (this.name == "Score")
            {
                scoreText.text = "Score: " + score.ToString();
            }
            else if (this.name == "BestScore")
            {
                scoreText.text = "Best score: " + bestScore.ToString();
                PlayerPrefs.SetInt("BestScore", bestScore);

                if (score > bestScore)
                {
                    bestScore = score;
                }
            }
        }

        

    }
}