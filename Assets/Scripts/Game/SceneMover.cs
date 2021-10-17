using UnityEngine;

namespace Game
{
    public class SceneMover : MonoBehaviour
    {
        public float movementSpeed = 3f;
        void FixedUpdate()
        {
            transform.Translate(Vector3.right * movementSpeed * Time.fixedDeltaTime);
        }
    }
}
