using UnityEngine;

public class ErlenmeyerZone : MonoBehaviour
{
    public GameObject erlenmeyerCorrect1;
    public TaskManager taskManager;
    private bool taskCompleted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (taskCompleted)
            return;

        if (other.gameObject == erlenmeyerCorrect1)
        {
            taskCompleted = true;
            taskManager.SetErlenmeyerInZone();
        }
    }
}
