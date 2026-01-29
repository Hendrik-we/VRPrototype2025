using UnityEngine;
using TMPro;

public class CleanTable : MonoBehaviour
{
    public TextMeshProUGUI textSponge;
    public TaskManager taskManager;
    private bool alreadyClicked = false;
    

    public void clickSponge()
    {
        if (alreadyClicked)
            return;

        alreadyClicked = true;

        taskManager.SetTableCleaned(true);


    }


}