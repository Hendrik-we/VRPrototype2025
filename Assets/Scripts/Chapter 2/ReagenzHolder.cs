using UnityEngine;
using TMPro;



public class ReagenzHolder : MonoBehaviour
{
    public Transform snapPoint;
    public TaskManager2 taskManager2;
    public GameObject correctGlass;
    public TextMeshProUGUI erlenmeyerText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == correctGlass)
        {
            UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            var rb = other.GetComponent<Rigidbody>();

            if (grab != null)
            { 
                if (grab.firstInteractorSelecting != null)
                {
                    grab.interactionManager.SelectExit(grab.firstInteractorSelecting, grab);
                }


                other.transform.position = snapPoint.position;
                other.transform.rotation = snapPoint.rotation;

                other.transform.SetParent(snapPoint);

                if (rb != null)
                {
                    rb.isKinematic = true;
                    rb.useGravity = false;

                }


                grab.enabled = false;

                erlenmeyerText.text = "Säure X - gekühlt";
                taskManager2.SetGlassInZone();
            }

        }
        
    }

}
