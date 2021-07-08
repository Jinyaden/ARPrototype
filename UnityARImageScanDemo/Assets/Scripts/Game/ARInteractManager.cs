using UnityEngine;
using ARImageTrackingDemo.Menu;

namespace ARImageTrackingDemo.Interaction
{
    public class ARInteractManager : MonoBehaviour
    {
        //[SerializeField] private GameObject particleEffectPrefab;
        [SerializeField] private ARMenu arMenu;
        [SerializeField] private Camera arCamera;
        private Vector2 touchPos;

        void Update()
        {
            OnTouchEnableMenu();       
        }

        void OnTouchEnableMenu()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                touchPos = touch.position;

                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = arCamera.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.CompareTag("Interactible"))
                        {
                            // Open Menu at location
                            hit.transform.GetComponent<IMenu>().EnableMenu();
                            arMenu.currentInteractiblePrefab = hit.transform.gameObject;
                        }
                    }
                }
            }
        }
    }
}
