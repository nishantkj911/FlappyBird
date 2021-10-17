using System;
using UnityEngine;

namespace Player
{
    public class DestroyPlayer : MonoBehaviour
    {
        [SerializeField] private float yThreshold = -100f;
        private void Update()
        {
            if (transform.position.y <= yThreshold)
            {
                gameObject.SetActive(false);
            }
        }
    }
}