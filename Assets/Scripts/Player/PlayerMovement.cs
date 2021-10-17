using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float jumpSpeed = 5f;
        [SerializeField] private AudioSource playerJumpAudio;
        
        public UnityEvent PlayerDie;
        public static event Action PlayerCrossPillar;

        private void Update()
        {
           
            if (Input.GetButtonDown("Jump") ||  Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // TODO: There is a bug where the pause button (touch) input is also registered as an input to this function, and on resuming, the player executes a jump.
                rb.velocity = Vector2.up * jumpSpeed;
                playerJumpAudio.Play();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            // Debug.Log($"Name: {other.gameObject.name}, Tag: {other.gameObject.tag}");
            if (other.gameObject.CompareTag("Walls"))
            {
                PlayerDie.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            // Debug.Log(other.name);
            if (other.gameObject.CompareTag("Pillar"))
            {
                PlayerCrossPillar?.Invoke();
            }
        }
    }
}