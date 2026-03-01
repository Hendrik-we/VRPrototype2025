using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public bool isRunning = false;
    public float currentTime = 0f;
    public TextMeshProUGUI timertext;
    public GameObject timer;

    public void StartTimer()
    {
        currentTime = 0f;
        isRunning = true;
        timer.SetActive(true);

    }

    public void StopTimer()
    {
        isRunning = false;
        timer.SetActive(false);
    }

    private void Update()
    {
        if (isRunning)
            currentTime += Time.deltaTime;
            timertext.text = currentTime.ToString("F2") + "s";
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
