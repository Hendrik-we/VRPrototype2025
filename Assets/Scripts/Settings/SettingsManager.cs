using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public ChapterManager chapterManager;


    private int nCompletedTasks = 0;
    private int activeTask = 0;
    private bool activeChapter = false;

    Dictionary<int, string> tasks = new Dictionary<int, string>()
    {
        {1, "Nimm die nötigen Einstellungen vor, mit denen du den Durchlauf bestreiten willst und bestätige diese auf dem Knopf."},
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

    //Task1
    public void SetSettingsDone(bool value)
    {
        if (value)
        {
            CheckTask(1);
        }
    }
}
