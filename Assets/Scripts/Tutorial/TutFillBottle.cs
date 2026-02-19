using TMPro;    
using UnityEngine;

public class TutFillBottle : MonoBehaviour
{
    public GameObject bottle;
    public TutorialManager tutorialManager;
    public TextMeshProUGUI erlenmeyerText;
    public bool hasLiquid = false;
    public GameObject liquid;
    public TutAnalysisZone analysisZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bottle && !hasLiquid)
        {
            hasLiquid = true;
            liquid.SetActive(true);
            tutorialManager.ErlenmeyerFilled();
            erlenmeyerText.text = "Erlenmeyerkolben - Flüssigkeit";
            analysisZone.AllowAnalysis();
        }

    }

}
