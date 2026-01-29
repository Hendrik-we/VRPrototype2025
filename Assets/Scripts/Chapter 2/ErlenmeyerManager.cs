using UnityEngine;
using TMPro;

public class ErlenmeyerManager : MonoBehaviour
{
    
    public bool hasLiquid1 = false;
    public bool hasLiquid2 = false;
    public TextMeshProUGUI erlenmeyerText;
    public TaskManager2 taskManager2;
    public GameObject liquid1;
    public GameObject liquid2;
    public GameObject liquidMixed;

    public void AddLiquid1()
    {
        if (!hasLiquid1)
        {
            hasLiquid1 = true;
            if (!hasLiquid2)
            {
                liquid1.SetActive(true);
            }
            CheckLiquids();
        }   
    }
    
    public void AddLiquid2()
    {
        if (!hasLiquid2)
        {
            hasLiquid2 = true;
            if (!hasLiquid1)
            {
                liquid2.SetActive(true);
            }
            CheckLiquids();
        }
    }


    private void CheckLiquids()
    {
        UpdateErlenmeyerText();
        if (hasLiquid1 && hasLiquid2)
        {
            liquid1.SetActive(false);
            liquid2.SetActive(false);
            liquidMixed.SetActive(true);
            taskManager2.SetMixed();
        }
    }

    private void UpdateErlenmeyerText()
    {
        if (hasLiquid1 && hasLiquid2)
        {
            erlenmeyerText.text = "Säure X";
        }
        else if (hasLiquid1)
        {
            erlenmeyerText.text = "Pufferlösung A.";
        }
        else if (hasLiquid2)
        {
            erlenmeyerText.text = "Lösung B - 10%.";
        }
        else
        {
            erlenmeyerText.text = "Erlenmeyerkolben ist leer.";
        }
    }



}
