using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class TaskManager3 : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public Slider progressBar;
    public ChapterManager chapterManager;

    private int completedTasks = 0;
    private int activeTask = 0;
    private bool activeChapter = false;

    Dictionary<int, string> tasks = new Dictionary<int, string>()
    {
        {1, "Aufgabe 1: Spüle das Glas der Pufferlösung A, Lösung B und den Erlenmeyerkolben aus!"},
        {2, "Aufgabe 2: Stell alle ausgespülten Behälter zurück in das Regal!"},
        {3, "Aufgabe 3: Leg Schutzbrille und Handschuhe ab!" },
        {4, "Aufgabe 4: Schalte die Arbeitsflächenbeleuchtung aus!" },
        {5, "Kapitel 3 abgeschlossen!" }
    };


    public void StartChapter3()
    {
        activeChapter = true;
        taskText.text = "Laborschulung - Kapitel 3: Nachbereitung und Entsorgung";
        StartCoroutine(StartTask(1));
        progressBar.value = 0;
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
            chapterManager.CheckChapter3();
        }
    }

    private void CheckTask(int value)
    {
        if (activeChapter || activeTask == value)
        {
            completedTasks = completedTasks + 1;
            progressBar.value = (float)completedTasks / tasks.Count;
            taskText.text = $"Aufgabe {value} erledigt!";

            StartCoroutine(StartTask(value + 1));
        }
    }

    //Task1

}
