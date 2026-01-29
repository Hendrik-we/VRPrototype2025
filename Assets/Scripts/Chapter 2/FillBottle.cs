using UnityEngine;

public class FillBottle : MonoBehaviour
{
    public GameObject bottle1;
    public GameObject bottle2;
    public GameObject bottle21;
    public ErlenmeyerManager erlenmeyerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bottle1)
        {
            erlenmeyerManager.AddLiquid1();
        }
        else if (other.gameObject == bottle2 || other.gameObject == bottle21)
        {
            erlenmeyerManager.AddLiquid2();

        }
    }


}
