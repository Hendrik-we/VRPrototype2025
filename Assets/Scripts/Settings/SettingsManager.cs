using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public ChapterManager chapterManager;
    public SettingCategory settingPresentation;
    public SettingCategory settingProgressbar;
    public SettingCategory settingTimer;
    public SettingCategory settingClue;

    public string labelPresentation;
    public string labelProgressbar;
    public string labelClue;
    public string labelTimer;


    private int nCompletedTasks = 0;
    private int activeTask = 0;
    private bool activeChapter = false;

    Dictionary<int, string> tasks = new Dictionary<int, string>()
    {
        {1, "Nimm die nötigen Einstellungen vor, mit denen du den Durchlauf bestreiten willst. Bestätige die Einstellungen und starte das Tutorial mit einem Klick auf die Tür."},
        {2, "Einstellungen bestätigt!"}
    };

    public void StartChapter()
    {
        activeChapter = true;
        taskText.text = "Laborschulung - Einstellungen";
        StartCoroutine(StartTask(1));
    }

    private IEnumerator StartTask(int value)
    {
        yield return new WaitForSeconds(5f);
        taskText.text = tasks[value];
        activeTask = value;

        if (value == tasks.Count)
        {
            yield return new WaitForSeconds(5f);
            activeChapter = false;
            chapterManager.CheckSettings();
        }
    }

    private void CheckTask(int value)
    {
        if (activeChapter && activeTask == value)
        {

            nCompletedTasks = nCompletedTasks + 1;
            taskText.text = $"Aufgabe {value} erledigt!";


            StartCoroutine(StartTask(value + 1));
        }
    }

    public void ApplySettings()
    {
        labelClue = settingClue.GetCurrentOption();
        labelPresentation = settingPresentation.GetCurrentOption();
        labelProgressbar = settingProgressbar.GetCurrentOption();
        labelTimer = settingTimer.GetCurrentOption();

        chapterManager.labelTimer = labelTimer switch
        {
            "An" => 0,
            _ => 1
        };

        chapterManager.labelProgressbar = labelProgressbar switch
        {
            "An" => 0,
            _ => 1
        };

        chapterManager.labelClue = labelClue switch
        {
            "Dezent" => 0,
            "Auffällig" => 1,
            _ => 2
        };

        chapterManager.labelPresentation = labelPresentation switch
        {
            "Professor" => 1,
            _ => 0
        };

    }

    //Task1
    public void SetSettingsDone()
    {
        CheckTask(1);
    }


}
