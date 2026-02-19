using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    public static HighlightManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Highlight(HighlightableObject obj)
    {
        obj.StartHighlight();
    }

    public void StopHighlight(HighlightableObject obj)
    {
        obj.StopHighlight();
    }
}
