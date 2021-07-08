using UnityEngine;
using UnityEngine.SceneManagement;

namespace ARImageTrackingDemo.Menu
{
    public class ARMenu : MonoBehaviour, IMenu
    {
        [SerializeField] private GameObject ARMenuObject;
        public GameObject currentInteractiblePrefab;

        void Start()
        {
            DisableMenu();
        }

        public void EnableMenu()
        {
            ARMenuObject.SetActive(true);
        }

        public void DisableMenu()
        {
            ARMenuObject.SetActive(false);
        }

        public void Exit()
        {
            SceneManager.LoadScene(0); // scene 0 being the first index of the build options, in this case the main menu
        }

        public void AnimateButton()
        {
            currentInteractiblePrefab.GetComponent<IInteractable>().Animate();
        }

        public void SwapMeshButton()
        {
            currentInteractiblePrefab.GetComponent<IInteractable>().SwapMesh();
        }

        public void ResetMeshButton()
        {
            currentInteractiblePrefab.GetComponent<IInteractable>().ResetMesh();
        }
    }
}
