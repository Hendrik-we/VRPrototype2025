using UnityEngine;
using System.Collections;
using TMPro;

public class HeatBottle : MonoBehaviour
{
    public TextMeshProUGUI erlenmeyerText;
    public TaskManager2 taskManager2;
    public AnalysisManager analysismanager;

    private bool isHeating = false;
    private float currentTemperature = 20f;
    private float targetTemperature = 40f;
    private Coroutine heatingRoutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeatZone"))
        {
            isHeating = true;
            if (heatingRoutine == null) {
                StartCoroutine(HeatProcess());
            }
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HeatZone"))
        {
            isHeating = false;
        }
        if (heatingRoutine != null)
        {
            StopCoroutine(heatingRoutine);
            heatingRoutine = null;
        }
    }

    private IEnumerator HeatProcess()
    {
        while (currentTemperature < targetTemperature)
        {
            if (!isHeating)
            {
                yield break;
            }
            currentTemperature += 2f;
            erlenmeyerText.text = $"Temperatur: {currentTemperature}°C";

            yield return new WaitForSeconds(1f);
        }

        erlenmeyerText.text = $"Temperatur: {targetTemperature}°C";
        analysismanager.EnableAnalysis();
        taskManager2.SetHeated();
        heatingRoutine = null;
    }

}
