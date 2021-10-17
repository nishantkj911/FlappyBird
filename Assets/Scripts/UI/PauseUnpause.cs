using Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class PauseUnpause : MonoBehaviour
    {
        [SerializeField] private Button resumeButton, mainMenuButton, pauseButton;
        [SerializeField] private GameObject GameOverUI, PausedUI, GameUI, player;

        private UnityEvent GamePaused, GameUnpaused;

        private bool gameIsPaused;

        private void Awake()
        {
            GamePaused = new UnityEvent();
            GameUnpaused = new UnityEvent();
            
            GameOverUI.SetActive(false);
            PausedUI.SetActive(false);
            GameUI.SetActive(true);
        }

        private void OnEnable()
        {
            GamePaused.AddListener(PauseGame);
            pauseButton.onClick.AddListener(PauseGame);
            
            GameUnpaused.AddListener(UnPauseGame);
            resumeButton.onClick.AddListener(UnPauseGame);
            mainMenuButton.onClick.AddListener(UnPauseGame);
        }
    
        private void OnDisable()
        {
            GamePaused.RemoveListener(PauseGame);
            pauseButton.onClick.AddListener(PauseGame);
            
            GameUnpaused.RemoveListener(UnPauseGame);
            resumeButton.onClick.RemoveListener(UnPauseGame);
            mainMenuButton.onClick.RemoveListener(UnPauseGame);
        }


        private void Update()
        {
            if (Input.GetButtonDown("Pause"))
            {
                gameIsPaused = !gameIsPaused;
                if (gameIsPaused)
                {
                    GamePaused.Invoke();
                }
                else
                {
                    GameUnpaused.Invoke();
                }
            }
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            GameUI.SetActive(false);
            PausedUI.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            gameIsPaused = true;
        }

        private void UnPauseGame()
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            GameUI.SetActive(true);
            PausedUI.SetActive(false);
            Time.timeScale = 1;
            gameIsPaused = false;
        }
    }
}
