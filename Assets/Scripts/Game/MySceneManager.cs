using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class MySceneManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text loadingText;
        
        private static MySceneManager instance;

        private void Awake()
        {
            if (loadingText)
            {
                loadingText.gameObject.SetActive(false);
            }
            
            // singleton
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
        
        public void LoadScene(string scene)
        {
            if (loadingText != null)
            {
                loadingText.gameObject.SetActive(true);
            }
            StartCoroutine(LoadGameAsync("Scenes/" + scene));
        }
        
        private IEnumerator LoadGameAsync(string scene)
        {
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(scene);

            while (!sceneLoading.isDone)
            {
                yield return null;
            }
        }
    }
}