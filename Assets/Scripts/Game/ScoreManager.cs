using Player;
using UnityEngine;

namespace Game
{
    public class ScoreManager : MonoBehaviour
    {
            
        private static int score;
        private static int highScore;

        public static int Score => score;
        public static int HighScore => highScore;

        private void OnEnable()
        {
            PlayerMovement.PlayerCrossPillar += IncreaseScore;
            score = 0;
        }

        private void OnDisable()
        {
            PlayerMovement.PlayerCrossPillar -= IncreaseScore;
        }

        private void LateUpdate()
        {
            highScore = Mathf.Max(score, highScore);
        }

        private static void IncreaseScore()
        {
            score += 1;
        }
    }
}