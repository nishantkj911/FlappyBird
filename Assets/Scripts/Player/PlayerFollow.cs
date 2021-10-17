using UnityEngine;

namespace Player
{
    public class PlayerFollow : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;

        private Vector2 offsetXZ;
        void Start()
        {
            offsetXZ.x = transform.position.x - playerTransform.position.x;
            offsetXZ.y = transform.position.z - playerTransform.position.z;
        }

        void FixedUpdate()
        {
            transform.position = new Vector3(playerTransform.position.x + offsetXZ.x, transform.position.y,
                playerTransform.position.z + offsetXZ.y);
        }
    }
}
