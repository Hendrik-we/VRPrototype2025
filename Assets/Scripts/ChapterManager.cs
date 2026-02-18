using UnityEngine;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour
{

    public SettingsManager settingsManager;
    public TutorialManager tutorialManager;
    public TaskManager taskManager1;
    public TaskManager2 taskManager2;
    public TaskManager3 taskManager3;
    public TimerManager timerManager;
    public ScoreboardManager scoreboardManager;

    public int labelTimer;
    public int labelProgressbar;
    public int labelClue;
    public int labelPresentation;

    public Slider progressbar;

    private string playerName = "Henny";

    void Start()
    {
        settingsManager.StartChapter();
    }

    public void CheckSettings()
    {
        ApplyProgressbarSettings();
        ApplyTimerSettings();
        StartTutorial();
    }

    private void ApplyProgressbarSettings()
    {
        if (labelProgressbar == 1)
        {
            progressbar.gameObject.SetActive(false);
        }
        else
        {
            progressbar.gameObject.SetActive(true);
        }
    }

    private void ApplyTimerSettings()
    {
        if (labelTimer == 0)
        {
            timerManager.StartTimer();
        }
    }

    private void StartTutorial()
    {
        tutorialManager.StartChapter();
    }

    public void CheckTutorial()
    {
        StartChapter1();
    }

    private void StartChapter1()
    {
        taskManager1.StartChapter();
    }
    public void CheckChapter1()
    {
        StartChapter2();
    }

    private void StartChapter2()
    {
        taskManager2.StartChapter();
    }

    public void CheckChapter2()
    {
        StartChapter3();
    }

    private void StartChapter3()
    {
        taskManager3.StartChapter();
    }

    public void CheckChapter3()
    {
        if (labelTimer == 0)
        {
            timerManager.StopTimer();
            float finalTime = timerManager.GetFinalTime();
            scoreboardManager.AddEntry(playerName, finalTime);
        }

    }

}