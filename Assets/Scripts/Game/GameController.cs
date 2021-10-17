using Player;
using TMPro;
using UI;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject gameUI;
        [SerializeField] private TMP_Text gameOverScoreText;

        public void DoGameOver()
        {

            // disable Player Components 
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Collider2D>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            player.transform.Rotate(0, 0, -180);

            // TODO: Bird bounces off the wall when dying. Real game has it falling directly down. Figure out why (even if is not to be changed)
            // Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            // playerRb.velocity = new Vector2(0, playerRb.velocity.y);

            // Modify UI elements
            gameUI.SetActive(false);
            GetComponent<PauseUnpause>().enabled = false;
            gameOverScoreText.text = "Score: " + ScoreManager.Score;
            gameOverScreen.SetActive(true);
        }
    }
}