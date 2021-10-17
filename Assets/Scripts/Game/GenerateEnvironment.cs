using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Game
{
    public class GenerateEnvironment : MonoBehaviour
    {
        [SerializeField] private Transform playerPosition;
        [SerializeField] private GameObject pillarObstacle;
        [SerializeField] private Vector2 yPillarLimits;

        private float xOffsetToGenerateNewEnv = 10f;
        private float interPillarDistance = 3f;
        private readonly Vector2 interPillarDistanceOffset = new Vector2(-0.5f, 2f);
        private float generateNextAt;

        private float totalDecrement = 0.6f;
        private float currentDecrement = 0f;
        private float decrementInterval = 0.06f;

        private void Start()
        {
            generateNextAt = playerPosition.position.x + xOffsetToGenerateNewEnv;
        }

        private void Update()
        {
            if (!(playerPosition.position.x + xOffsetToGenerateNewEnv >= generateNextAt)) return;
            GeneratePillar();
            generateNextAt += interPillarDistance + Random.Range(interPillarDistanceOffset.x, interPillarDistanceOffset.y);
        }

        private void GeneratePillar()
        {
            // Debug.Log("Generate Pillar");
            float pillarY = Random.Range(yPillarLimits.x, yPillarLimits.y);
            
            // Increase difficulty by decreasing the distance between the pillars.
            float dy = GetYDecrementValue();
            GameObject newPillarInstance = Instantiate(pillarObstacle, new Vector3(generateNextAt, pillarY, 0), Quaternion.identity);
            if (dy > 0)
            {
                for (int i = 0; i < newPillarInstance.transform.childCount; i++)
                {
                    if (newPillarInstance.transform.GetChild(i).localPosition.y > 0)
                    {
                        newPillarInstance.transform.GetChild(i).position -= Vector3.up * dy;
                    }
                    else
                    {
                        newPillarInstance.transform.GetChild(i).localPosition += (Vector3.up * dy);
                    }

                }
            }
        }

        // decrement value until total decrement is 
        private float GetYDecrementValue()
        {
            if (currentDecrement < totalDecrement)
            {
                currentDecrement += decrementInterval;
                return currentDecrement;
            }

            return totalDecrement;
        }
    }
}