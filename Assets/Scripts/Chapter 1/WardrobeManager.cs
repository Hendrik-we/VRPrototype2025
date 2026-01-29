using UnityEngine;
using TMPro;

public class WardrobeManager : MonoBehaviour
{
    public TextMeshProUGUI statusText;

    public bool hasHelmet;
    public bool hasGloves;
    public bool hasGlasses;
    public TaskManager taskManager;

    public void ToggleHelmet()
    {
        hasHelmet = !hasHelmet;
        UpdateStatus();
        taskManager.CheckClothes(hasGlasses, hasGloves, hasHelmet);
    }

    public void ToggleGloves()
    {
        hasGloves = !hasGloves;
        UpdateStatus();
        taskManager.CheckClothes(hasGlasses, hasGloves, hasHelmet);
    }

    public void ToggleGlasses()
    {
        hasGlasses = !hasGlasses;
        UpdateStatus();
        taskManager.CheckClothes(hasGlasses, hasGloves, hasHelmet);
    }

    private void UpdateStatus()
    {
        statusText.text = "Du trägst gerade:\n";

        if (hasHelmet) statusText.text += "- Helm\n";
        if (hasGloves) statusText.text += "- Handschuhe\n";
        if (hasGlasses) statusText.text += "- Brille\n";

        if (!hasHelmet && !hasGloves && !hasGlasses)
            statusText.text += "- Nichts";
    }


}
