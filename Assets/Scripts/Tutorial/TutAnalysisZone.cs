using TMPro;
using UnityEngine;

public class TutAnalysisZone : MonoBehaviour
{
    public bool analysisAllowed = false;
    public GameObject erlenmeyer;
    public TextMeshProUGUI erlenmeyerText;
    public TutorialManager tutorialManager;
    public TutWadrobe tutWadrobe;

    private bool erlenmeyerInside = false;
    private float analysisProgress = 0f;

    public void AllowAnalysis()
    {
        analysisAllowed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == erlenmeyer && analysisAllowed)
        {
            erlenmeyerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == erlenmeyer)
        {
            erlenmeyerInside = false;
        }
    }

    private void Update()
    {
        if (!analysisAllowed || !erlenmeyerInside)
            return;

        analysisProgress += 5f * Time.deltaTime;

        erlenmeyerText.text = $"Erlenmeyerkolben - Analyse: {Mathf.Clamp(analysisProgress, 0, 100):0}%";

        
        if (analysisProgress >= 100f)
        {
            analysisProgress = 100f;
            erlenmeyerInside = false; 
            erlenmeyerText.text = "Erlenmeyerkolben - Analyse abgeschlossen";

            tutorialManager.ErlenmeyerAnalyzed();
            tutWadrobe.AllowGlovesOff();
        }


    }
}

