using UnityEngine;
using TMPro;

public class TutWadrobe : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public bool hasGloves;
    public TutorialManager tutorialManager;
    public GameObject button;

    public bool allowGlovesOff = false;

    private bool glovesOnOnce = false;
    public void ToggleGloves()
    {
        if (!allowGlovesOff && hasGloves == false)
        {
            hasGloves = true;
            UpdateStatus();

            if (!glovesOnOnce)
            {
                glovesOnOnce = true;
                tutorialManager.SetGlovesOn();
            }

            return;
        }

        if (allowGlovesOff)
        {
            hasGloves = !hasGloves;
            UpdateStatus();


            if (!hasGloves)
            {
                tutorialManager.SetGlovesOff();
                button.SetActive(true);
            }

            return;
        }
    }

    private void UpdateStatus()
    {
        statusText.text = "Du trägst gerade:\n";

        if (hasGloves)
            statusText.text += "- Handschuhe\n";
        else
            statusText.text += "- Nichts";
    }

    public void AllowGlovesOff()
    {
        allowGlovesOff = true;
    }
}
