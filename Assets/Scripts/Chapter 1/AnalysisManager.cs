using UnityEngine;
using TMPro;

public class AnalysisManager : MonoBehaviour
{
    public GameObject bottlecorrect1;
    public GameObject bottlewrong1;
    public TextMeshProUGUI textbottlecorrect1;
    public TextMeshProUGUI textbottlewrong1;
    public TaskManager taskManager;
    
    public GameObject erlenmeyercorrect1;
    public TextMeshProUGUI texterlenmeyercorrect1;
    public TextMeshProUGUI texterlenmeyertemperatur;
    public TaskManager2 taskManager2;

    private bool erlenmeyerenabled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bottlecorrect1)
        {
            textbottlecorrect1.text = "Lösung B - 10%";
            taskManager.SetBottle2Analyzed();
        }
        else if (other.gameObject == bottlewrong1)
        {
            textbottlewrong1.text = "Lösung B - 85%";
        }
        else if (other.gameObject == erlenmeyercorrect1 && erlenmeyerenabled == true)
        {
            texterlenmeyercorrect1.text = "Säure X - 5%";
            texterlenmeyertemperatur.gameObject.SetActive(false);
            taskManager2.SetAnalyzed();
        }
    }

    public void EnableAnalysis()
    {
        erlenmeyerenabled = true;
    }


}
