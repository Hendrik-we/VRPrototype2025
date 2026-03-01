using UnityEngine;
using System.Collections;
public class LowHighlightableObject : MonoBehaviour
{
    public Renderer targetRenderer;
    public Color highlightColor = Color.white;
    public float pulseSpeed = 5f;
    public float delay = 30f;

    private Color originalColor;
    private bool isHighlighted = false;
    private bool isWaiting = false;
    private Coroutine highlightRoutine;

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
        if (isWaiting || isHighlighted)
            return;

        isWaiting = true;
        highlightRoutine = StartCoroutine(DelayedHighlight());
    }

    public void StopHighlight()
    {
        if (highlightRoutine != null)
            StopCoroutine(highlightRoutine);
        
        isWaiting = false;
        isHighlighted = false;
        targetRenderer.material.color = originalColor;
    }

     private IEnumerator DelayedHighlight()
    {
        yield return new WaitForSeconds(delay);

        if(isWaiting)
        {
            isWaiting = false;
            isHighlighted = true;
        }

    }
}
