using TMPro;
using UnityEngine;

public class SettingCategory : MonoBehaviour
{
    public TextMeshPro optionLabel;
    public string[] options;
    public int currentIndex = 0;

    public void Start()
    {
        UpdateOptionLabel();
    }

    public void NextOption()
    {
        currentIndex = (currentIndex + 1) % options.Length;
        UpdateOptionLabel();
    }

    private void UpdateOptionLabel()
    {
        optionLabel.text = options[currentIndex];
    }

    public string GetCurrentOption()
    {
        return options[currentIndex];
    }
}
