using Game;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UpdateScoresOnUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _highscoreText;

        private void LateUpdate()
        {
            _scoreText.text = ScoreManager.Score.ToString();
            _highscoreText.text = ScoreManager.HighScore.ToString();
        }
    }
}
