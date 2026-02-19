using UnityEngine;

public class PlacingZone : MonoBehaviour
{
    public GameObject erlenmeyerCorrect1;
    public TutorialManager tutorialManager;
    private bool taskCompleted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (taskCompleted)
            return;

        if (other.gameObject == erlenmeyerCorrect1)
        {
            taskCompleted = true;
            tutorialManager.ErlenmeyerPlaced();
        }
    }

}
