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
    public HighlightManager highlightManager;
    public int highlightLabel;

    public HighlightableObject puffer;
    public HighlightableObject erlenmeyer;
    public HighlightableObject loesung1;
    public HighlightableObject ofen;
    public HighlightableObject analysis;
    public HighlightableObject kuehl;
    public HighlightableObject kuehlwall;
    public HighlightableObject reagenz;
    public HighlightableObject halterung;
    

    private int completedTasks = 0;
    private int activeTask = 0;
    private bool activeChapter = false;

    Dictionary<int, string> tasks = new Dictionary<int, string>()
    {
        {1, "Aufgabe 1: Fülle die Pufferlösung A und Lösung B - 10% in den Erlenmeyerkolben!"},
        {2, "Aufgabe 2: Erhitze die Säure X auf der Heizfläche, bis diese 40°C hat!"},
        {3, "Aufgabe 3: Nutze die Analysemaschine, um zu prüfen, ob die Säure X 5% hat!"},
        {4, "Aufgabe 4: Stell die Säure X - 5% in den Kühlraum!"},
        {5, "Aufgabe 5: Stell ein Reagenzglas in die dafür vorgesehene Halterung auf der Arbeitsfläche!" },
        {6, "Aufgabe 6: Gib Säure X - gekühlt in das Reagenzglas!" },
        {7, "Aufgabe 7: Warte ab bis aus der Säure X - gekühlt die Reaktionslösung wird." },
        {8, "Kapitel 2 abgeschlossen!" }
    };


    public void StartChapter()
    {
        activeChapter = true;
        taskText.text = "Laborschulung - Kapitel 2: Herrstellung der Reaktionslösung";
        StartCoroutine(StartTask(1));
        progressBar.value = 0;
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.Highlight(puffer);
            HighlightManager.Instance.Highlight(loesung1);
        }
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
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(puffer);
            HighlightManager.Instance.StopHighlight(loesung1);
            HighlightManager.Instance.Highlight(ofen);
        }
    }

    //Task2
    public void SetHeated()
    {
        CheckTask(2);
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(ofen);
            HighlightManager.Instance.Highlight(analysis);
        }
    }

    //Task3
    public void SetAnalyzed()
    {
        CheckTask(3);
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(analysis);
            HighlightManager.Instance.Highlight(kuehl);
            HighlightManager.Instance.Highlight(kuehlwall);
        }
    }

    //Task4
    public void SetCooled()
    {
        CheckTask(4);
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(kuehl);
            HighlightManager.Instance.StopHighlight(kuehlwall);
            HighlightManager.Instance.Highlight(reagenz);
            HighlightManager.Instance.Highlight(halterung);
        }
    }

    //Task5
    public void SetGlassInZone()
    {
        CheckTask(5);
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(halterung);
            HighlightManager.Instance.Highlight(erlenmeyer);
        }
    }

    //Task6
    public void SetGlassFilled()
    {
        CheckTask(6);
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(reagenz);
            HighlightManager.Instance.StopHighlight(erlenmeyer);
        }
    }

    //Task7
    public void SetReactionDone()
    {
        CheckTask(7);
    }
}
