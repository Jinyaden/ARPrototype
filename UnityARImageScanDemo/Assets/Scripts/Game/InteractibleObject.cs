using UnityEngine;
using ARImageTrackingDemo.Manager;

namespace ARImageTrackingDemo.ARObject
{
    public class InteractibleObject : MonoBehaviour, IInteractable
    {
        [SerializeField] GameObject[] imagePrefabs;
        private GameObject currentPrefab;
        private ImageTrackingManager trackedImage => GetComponent<ImageTrackingManager>();

        void Start()
        {
            currentPrefab = Instantiate(imagePrefabs[0], trackedImage.transform.position, Quaternion.identity);
        }

        public void Animate()
        {
            // Play animation
        }

        public void ResetMesh()
        {
            Destroy(currentPrefab);
        }

        public void SwapMesh()
        {
            if (currentPrefab == imagePrefabs[0])
            {
                Destroy(currentPrefab);
                currentPrefab = Instantiate(imagePrefabs[1], trackedImage.transform.position, Quaternion.identity);
            }
            else if (currentPrefab == null)
            {
                currentPrefab = Instantiate(imagePrefabs[0], trackedImage.transform.position, Quaternion.identity);
            }
        }
    }
}
