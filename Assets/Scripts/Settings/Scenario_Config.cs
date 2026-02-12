using UnityEngine;

public enum TaskDisplayMode
{
    AlwaysVisible,
    VisibleOnTaskStart,
    VisibleOnTaskCompletion
}

[CreateAssetMenu(fileName = "Scenario_Config", menuName = "Settings/Scenario Config")]
public class Scenario_Config : ScriptableObject
{
    public int roomNumber = 1;
    public TaskDisplayMode taskDisplayMode;
    public bool gamificationEnabled;
}
