using UnityEngine;


public class Bottle2Zone : MonoBehaviour
{
    public GameObject bottle2;
    public TaskManager taskManager;
    private bool taskCompleted = false;


    private void OnTriggerEnter(Collider other)
    {
        if (taskCompleted)
            return;

        if (other.gameObject == bottle2)
        {
            taskCompleted = true;
            taskManager.SetBottle2InZone();
        }
    }

}
