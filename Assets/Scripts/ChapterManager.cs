using UnityEngine;

public class ChapterManager : MonoBehaviour
{

    public SettingsManager settingsManager;
    public TutorialManager tutorialManager;
    public TaskManager taskManager1;
    public TaskManager2 taskManager2;
    public TaskManager3 taskManager3;

    void Start()
    {
        tutorialManager.StartChapter();
    }

    public void CheckSettings()
    {
        StartSettings();
    }
    private void StartSettings()
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
        return;
    }

}