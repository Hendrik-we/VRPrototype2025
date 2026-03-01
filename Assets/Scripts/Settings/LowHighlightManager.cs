using UnityEngine;

public class LowHighlightManager : MonoBehaviour
{
    public static LowHighlightManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Highlight(LowHighlightableObject obj)
    {
        obj.StartHighlight();
    }

    public void StopHighlight(LowHighlightableObject obj)
    {
        obj.StopHighlight();
    }
}
