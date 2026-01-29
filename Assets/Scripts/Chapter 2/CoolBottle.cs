using UnityEngine;

public class CoolBottle : MonoBehaviour
{
    public TaskManager2 taskManager2;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoolingZone"))
        {
            taskManager2.SetCooled();
        }
    }
}
