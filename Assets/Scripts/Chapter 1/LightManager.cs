using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightManager : MonoBehaviour
{
    public Light[] lightsToToggle;
    public TaskManager taskManager;
    public TaskManager3 taskManager3;
    public WardrobeManager wardrobeManager;
    private bool isOn = false;
    

    public void ButtonPressed()
    {
        isOn = !isOn;
        foreach (Light light in lightsToToggle)
        {
            light.enabled = isOn;
        }


        if (isOn)
        {
            taskManager.SetLightsOn(true);
        }

        if (!isOn && wardrobeManager.allowLightTask)
        {
            taskManager3.SetLightsOff();
        }
    }


}