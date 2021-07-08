using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace ARImageTrackingDemo.Manager
{
    [RequireComponent(typeof(ARTrackedImageManager))]
    public class ImageTrackingManager : MonoBehaviour
    {
        [SerializeField] private GameObject particleEffectPrefab; // prefabs to instantiate
        private ARTrackedImageManager trackedImageManager => GetComponent<ARTrackedImageManager>();
        private GameObject spawnedARPrefab;

        void Awake()
        {
                //instantiate the game objects then add to array
                spawnedARPrefab = Instantiate(particleEffectPrefab, Vector3.zero, Quaternion.identity);
        }

        void OnEnable()
        {
            trackedImageManager.trackedImagesChanged += OnImageChanged;
        }

        void OnDisable()
        {
            trackedImageManager.trackedImagesChanged -= OnImageChanged;
        }

        void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (ARTrackedImage trackedImage in eventArgs.added) // when image is tracked add object 
            {
                UpdateARImage(trackedImage);
            }

            
            foreach (ARTrackedImage trackedImage in eventArgs.updated) // when image is updated
            {
                UpdateARImage(trackedImage);
            }
            

            foreach (ARTrackedImage trackedImage in eventArgs.removed)
            {
                spawnedARPrefab.SetActive(false); // disable removed images prefab
            }
        }

        void UpdateARImage(ARTrackedImage trackedImage)
        {
            Vector3 pos = trackedImage.transform.position;

            GameObject prefab = spawnedARPrefab;
            prefab.transform.position = pos;
            prefab.SetActive(true);
        }

        public ARTrackedImage GetImagePosition(ARTrackedImage trackedImage)
        {
            return trackedImage;
        }
    }
}
