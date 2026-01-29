using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
// 

public class TaskManager2 : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public Slider progressBar;
    public ChapterManager chapterManager;

    private int completedTasks = 0;
    private int activeTask = 0;
    private bool activeChapter = false;

    Dictionary<int, string> tasks = new Dictionary<int, string>()
    {
        {1, "Aufgabe 1: Fülle die Pufferlösung A und Lösung B - 10% in den Erlenmeyerkolben!"},
        {2, "Aufgabe 2: Erhitze die Säure X auf der Heizfläche, bis diese 40°C hat!"},
        {3, "Aufgabe 3: Nutze die Analysemaschine, um zu prüfen, ob die Säure X 5% hat!"},
        {4, "Aufgabe 4: Stell die Säure X - 5% in den Kühlraum!"},
        {5, "Aufgabe 5: Stell ein Rehagenzglas in die dafür vorgesehene Halterung auf der Arbeitsfläche!" },
        {6, "Aufgabe 6: Gib Säure X - gekühlt in das Rehagenzglas!" },
        {7, "Aufgabe 7: Warte ab bis aus der Säure X - gekühlt die Reaktionslösung wird." },
        {8, "Kapitel 2 abgeschlossen!" }
    };


    public void StartChapter()
    {
        activeChapter = true;
        taskText.text = "Laborschulung - Kapitel 2: Herrstellung der Reaktionslösung";
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
            chapterManager.CheckChapter2();
        }
    }


    private void CheckTask(int value)
    {
        if (activeChapter && activeTask == value)
        {
            completedTasks = completedTasks + 1;
            progressBar.value = (float)completedTasks / tasks.Count;
            taskText.text = $"Aufgabe {value} erledigt!";

            StartCoroutine(StartTask(value + 1));
        }
    }

    //Task1
    public void SetMixed()
    {
        CheckTask(1);
    }

    //Task2
    public void SetHeated()
    {
        CheckTask(2);
    }

    //Task3
    public void SetAnalyzed()
    {
        CheckTask(3);
    }

    //Task4
    public void SetCooled()
    {
        CheckTask(4);
    }

    //Task5
    public void SetGlassInZone()
    {
        CheckTask(5);
    }

    //Task6
    public void SetGlassFilled()
    {
        CheckTask(6);
    }

    //Task7
    public void SetReactionDone()
    {
        CheckTask(7);
    }
}
