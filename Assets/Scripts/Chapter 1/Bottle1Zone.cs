using UnityEngine;


public class Bottle1Zone : MonoBehaviour
{
    public GameObject bottle1;
    public TaskManager taskManager;
    private bool taskCompleted = false;


    private void OnTriggerEnter(Collider other)
    {
        if (taskCompleted)
            return;

        if (other.gameObject == bottle1)
        {
            taskCompleted = true;
            taskManager.SetBottle1InZone();
        }
    }

}
