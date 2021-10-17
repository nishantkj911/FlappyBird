using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class CleanupGameObject : MonoBehaviour
    {
        [FormerlySerializedAs("playerPosition")] [SerializeField] private Transform playerTransform;
        [SerializeField] private string tagToRemove;
        [SerializeField] private float xOffsetBehindPlayer = 5f;

        void Update()
        {
            RemoveObjectsBehindPlayer();
        }

        private void RemoveObjectsBehindPlayer()
        {
            GameObject[] pillarInGame = GameObject.FindGameObjectsWithTag(tagToRemove);

            foreach (var pillar in pillarInGame)
            {
                if (pillar.transform.position.x <= playerTransform.position.x - xOffsetBehindPlayer)
                {
                    Destroy(pillar);
                }
            }
        }
    }
}
