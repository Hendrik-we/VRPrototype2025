using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;


public class TaskManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public Slider progressBar;
    public ChapterManager chapterManager;
    public TeleportManager teleportManager;
    public Transform startPoint;
    public HighlightManager highlightManager;
    public int highlightLabel;

    public HighlightableObject button;
    public HighlightableObject gloves;
    public HighlightableObject glasses;
    public HighlightableObject sponge;
    public HighlightableObject puffer;
    public HighlightableObject erlenmeyer;
    public HighlightableObject loesung1;
    public HighlightableObject loesung3;
    public HighlightableObject analysis;



    private int completedTasks = 0;
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
        teleportManager.TeleportTo(startPoint);
        activeChapter = true;
        taskText.text = "Laborschulung - Kapitel 1: Vorbereitung des Arbeitsplatzes";
        StartCoroutine(StartTask(1));
        progressBar.value = 0;
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.Highlight(button);
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
            chapterManager.CheckChapter1();
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
    public void SetLightsOn(bool value)
    {
        if (value)
        {
            if (highlightLabel == 1)
            {
                HighlightManager.Instance.StopHighlight(button);
                HighlightManager.Instance.Highlight(gloves);
                HighlightManager.Instance.Highlight(glasses);
            }
            CheckTask(1);
        }
    }

//Task2

    public void CheckClothes(bool hasGlasses, bool hasGloves, bool hasHelmet)
    {
        if (hasGlasses && hasGloves && !hasHelmet)
        {
            if (highlightLabel == 1)
            {
                HighlightManager.Instance.StopHighlight(gloves);
                HighlightManager.Instance.StopHighlight(glasses);
                HighlightManager.Instance.Highlight(sponge);
            }
            CheckTask(2);
        }
    }

//Task3
    public void SetTableCleaned(bool value)
    {
        if (value)
        {
            if (highlightLabel == 1)
            {
                HighlightManager.Instance.StopHighlight(sponge);
                HighlightManager.Instance.Highlight(puffer);
            }
            CheckTask(3);
        }
    }

//Task4
    public void SetBottle1InZone()
    {
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(puffer);
            HighlightManager.Instance.Highlight(erlenmeyer);
        }
        CheckTask(4);
    }

//Task5
    public void SetErlenmeyerInZone()
    {
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(erlenmeyer);
            HighlightManager.Instance.Highlight(loesung1);
            HighlightManager.Instance.Highlight(loesung3);
            HighlightManager.Instance.Highlight(analysis);
        }
        CheckTask(5);
    }

//Task6
    public void SetBottle2Analyzed()
    {
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(loesung1);
            HighlightManager.Instance.StopHighlight(loesung3);
            HighlightManager.Instance.StopHighlight(analysis);
        }
        CheckTask(6);
    }


//Task7
    public void SetBottle2InZone()
    {
        CheckTask(7);
    }
}
