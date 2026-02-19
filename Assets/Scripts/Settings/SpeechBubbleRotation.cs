using UnityEngine;

public class SpeechBubbleRotation : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        if (cam == null) return;

        // Bubble zur Kamera drehen
        transform.LookAt(cam.transform);

        // 180° drehen, damit die Vorderseite zur Kamera zeigt
        transform.Rotate(0, 180, 0);
    }
}
