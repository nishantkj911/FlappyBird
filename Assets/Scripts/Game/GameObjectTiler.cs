using UnityEngine;

namespace Game
{
    public class GameObjectTiler : MonoBehaviour
    {
        [SerializeField] private GameObject tiledObject;
        [SerializeField] private Vector3 tileOffset;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private string sortingLayer;
        
        private Vector3 nextLocation;
        private float xOffsetToGenerate = 10f;
        private int sortingOrder;

        private void Awake()
        {
            nextLocation = tiledObject.transform.position;
        }

        private void Update()
        {
            if (nextLocation.x - xOffsetToGenerate <= playerTransform.position.x)
            {
                TileNext();
            }
        }

        private void TileNext()
        {
            GameObject newInstance = Instantiate(tiledObject, nextLocation, Quaternion.identity);
            newInstance.GetComponent<Renderer>().sortingLayerName = sortingLayer;
            newInstance.GetComponent<Renderer>().sortingOrder = sortingOrder++;
            nextLocation += tileOffset;
        }
    }
}
