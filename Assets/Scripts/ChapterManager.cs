using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChapterManager : MonoBehaviour
{

    public SettingsManager settingsManager;
    public TutorialManager tutorialManager;
    public TaskManager taskManager1;
    public TaskManager2 taskManager2;
    public TaskManager3 taskManager3;
    public TimerManager timerManager;
    public ScoreboardManager scoreboardManager;
    public GameObject tutProfessor;
    public GameObject professor;
    public TextMeshProUGUI taskText;


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
        ApplyClueSettings();
        ApplyPresentationSettings();
        StartChapter1();
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

    private void ApplyClueSettings()
    {
        tutorialManager.highlightLabel = labelClue;
        taskManager1.highlightLabel = labelClue;
        taskManager2.highlightLabel = labelClue;
        taskManager3.highlightLabel = labelClue;
    }

    private void ApplyPresentationSettings()
    {
        if (labelPresentation == 1)
        {
            professor.SetActive(true);
            tutProfessor.SetActive(true);
            taskText.gameObject.SetActive(false);
        }
        else if(labelPresentation == 0)
        {
            professor.SetActive(false);
            tutProfessor.SetActive(false);
            taskText.gameObject.SetActive(true);
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
        settingsManager.ReturnToSettings();
    }

}