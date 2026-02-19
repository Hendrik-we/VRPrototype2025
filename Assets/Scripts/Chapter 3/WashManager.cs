using UnityEngine;



public class WashManager : MonoBehaviour
{
    public TaskManager3 taskManager;

    private bool washedErlenmeyer = false;
    private bool washedPuffer = false;
    private bool washedLoesung = false;

    public bool allownextTask = false;


    private void OnTriggerEnter(Collider other)
    {
        var glass = other.GetComponent<WashableGlass>();
        if (glass != null)
        {
            Debug.Log("WashableGlass erkannt: " + glass.glassType);
            Wash(glass);
        }
    }

    private void Wash(WashableGlass glass)
    {
        if(glass.isWashed)
        {
            return;
        }

        if(glass.liquid != null)
        {
            glass.liquid.SetActive(false);
        }

        glass.isWashed = true;

        switch(glass.glassType)
        {
            case GlassType.Erlenmeyer:
                washedErlenmeyer = true;
                break;
            case GlassType.Puffer:
                washedPuffer = true;
                break;
            case GlassType.Loesung:
                washedLoesung = true;
                break;
        }
        CheckAllWashed();

    }

    private void CheckAllWashed()
    {
        if(washedErlenmeyer && washedPuffer && washedLoesung)
        {
            allownextTask = true;
            taskManager.SetGlassesClean();
        }
    }

    public void ResetTask()
    {
        allownextTask = false;
    }
}
