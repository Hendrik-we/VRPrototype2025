using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class TaskManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public Slider progressBar;
    public ChapterManager chapterManager;

    private int nCompletedTasks = 0;
    private int activeTask = 0;
    private bool activeChapter = false;

    Dictionary<int, string> tasks = new Dictionary<int, string>()
    {
        {1, "Aufgabe 1: Schalte das Licht an!"},
        {2, "Aufgabe 2: Zieh ausschließlich die Handschuhe und 'Schutzbrille' an!"},
        {3, "Aufgabe 3: Reinige die Arbeitsfläche!"},
        {4, "Aufgabe 4: Stell die Pufferlösung A auf die Arbeitsfläche!"},
        {5, "Aufgabe 5: Stell den Erlenmeyerkolben auf die Arbeitsfläche!"},
        {6, "Aufgabe 6: Du benötigst ein Lösung B - 10%! Finde mithilfe des Analysegeräts heraus, welche du nutzen kannst!" },
        {7, "Aufgabe 7: Stell die Lösung B - 10% auf die Arbeitsfläche!" },
        {8, "Kapitel 1 abgeschlossen!"}
    };


    public void StartChapter()
    {
        activeChapter = true;
        taskText.text = "Laborschulung - Kapitel 1: Vorbereitung des Arbeitsplatzes";
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
            chapterManager.CheckChapter1();
        }
    }

    private void CheckTask(int value)
    {
        if (activeChapter && activeTask == value)
        {

            nCompletedTasks = nCompletedTasks + 1;
            progressBar.value = (float)nCompletedTasks / tasks.Count;
            taskText.text = $"Aufgabe {value} erledigt!";


            StartCoroutine(StartTask(value + 1));
        }
    }

//Task1
    public void SetLightsOn(bool value)
    {
        if (value)
        {
            CheckTask(1);
        }
    }

//Task2

    public void CheckClothes(bool hasGlasses, bool hasGloves, bool hasHelmet)
    {
        if (hasGlasses && hasGloves && !hasHelmet)
        {
            CheckTask(2);
        }
    }

//Task3
    public void SetTableCleaned(bool value)
    {
        if (value)
        {
            CheckTask(3);
        }
    }

//Task4
    public void SetBottle1InZone()
    {
        CheckTask(4);
    }

//Task5
    public void SetErlenmeyerInZone()
    {
        CheckTask(5);
    }

//Task6
    public void SetBottle2Analyzed()
    {
        CheckTask(6);
    }


//Task7
    public void SetBottle2InZone()
    {
        CheckTask(7);
    }
}
