using System;
using UnityEngine;

namespace Game
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip mainTheme;
        [SerializeField] private AudioSource currentAudioSource;
        [SerializeField] private bool loop;

        private static AudioManager singleInstance;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
            // Only one instance of AudioManager.
            if (singleInstance == null)
            {
                singleInstance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            currentAudioSource.clip = mainTheme;
            currentAudioSource.loop = loop;
        }

        private void Start()
        {
            currentAudioSource.Play();
        }
        
    }
}