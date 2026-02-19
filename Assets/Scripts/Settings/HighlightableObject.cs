using UnityEngine;

public class HighlightableObject : MonoBehaviour
{
    public Renderer targetRenderer;
    public Color highlightColor = Color.yellow;
    public float pulseSpeed = 5f;

    private Color originalColor;
    private bool isHighlighted = false;

    private void Start()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponent<Renderer>();

        originalColor = targetRenderer.material.color;
    }

    private void Update()
    {
        if (isHighlighted)
        {
            float t = (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f;
            targetRenderer.material.color = Color.Lerp(originalColor, highlightColor, t);
        }
    }

    public void StartHighlight()
    {
        isHighlighted = true;
    }

    public void StopHighlight()
    {
        isHighlighted = false;
        targetRenderer.material.color = originalColor;
    }
}
