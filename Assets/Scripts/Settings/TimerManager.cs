using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public bool isRunning = false;
    public float currentTime = 0f;

    public void StartTimer()
    {
        currentTime = 0f;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void Update()
    {
        if (isRunning)
            currentTime += Time.deltaTime;
    }

    public float GetFinalTime()
    {
        return currentTime;
    }

    public void ResetTimer()
    {
        currentTime = 0f;
        isRunning = false;
    }
}
