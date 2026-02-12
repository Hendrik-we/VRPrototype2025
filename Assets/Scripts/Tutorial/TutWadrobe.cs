using UnityEngine;
using TMPro;


public class TutWadrobe : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public bool hasGloves;
    public TutorialManager tutorialManager;

    public void ToggleGloves()
    {
        hasGloves = !hasGloves;
        UpdateStatus();
        tutorialManager.SetGlovesOn();
    }

    private void UpdateStatus()
    {
        statusText.text = "Du trägst gerade:\n";
        if (hasGloves) statusText.text += "- Handschuhe\n";
        if (!hasGloves) statusText.text += "- Nichts";
    }
}
