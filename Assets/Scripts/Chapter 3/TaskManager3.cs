using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class TaskManager3 : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public TextMeshPro profText;
    public Slider progressBar;
    public ChapterManager chapterManager;
    public HighlightManager highlightManager;
    public LowHighlightManager lowHighlightManager;
    public int highlightLabel;


    public HighlightableObject puffer;
    public HighlightableObject erlenmeyer;
    public HighlightableObject loesung1;
    public HighlightableObject gloves;
    public HighlightableObject glasses;
    public HighlightableObject button;

    public LowHighlightableObject puffer_low;
    public LowHighlightableObject erlenmeyer_low;
    public LowHighlightableObject loesung1_low;
    public LowHighlightableObject gloves_low;
    public LowHighlightableObject glasses_low;
    public LowHighlightableObject button_low;


    private int completedTasks = 0;
    private int activeTask = 0;
    private bool activeChapter = false;

    Dictionary<int, string> tasks = new Dictionary<int, string>()
    {
        {1, "Aufgabe 1: Spüle das Glas der Pufferlösung A, Lösung B und den Erlenmeyerkolben aus!"},
        {2, "Aufgabe 2: Zieh jegliche Sicherheitsausrüstung aus!" },
        {3, "Aufgabe 3: Schalte die Arbeitsflächenbeleuchtung aus!" },
        {4, "Kapitel 3 abgeschlossen!" }
    };

    public void StartChapter()
    {
        activeChapter = true;
        taskText.text = "Laborschulung - Kapitel 3: Nachbereitung und Entsorgung";
        profText.text = "Laborschulung - Kapitel 3: Nachbereitung und Entsorgung";
        StartCoroutine(StartTask(1));
        progressBar.value = 0;
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.Highlight(puffer);
            HighlightManager.Instance.Highlight(loesung1);
            HighlightManager.Instance.Highlight(erlenmeyer);
        }
        else if (highlightLabel == 0)
        {
            LowHighlightManager.Instance.Highlight(puffer_low);
            LowHighlightManager.Instance.Highlight(loesung1_low);
            LowHighlightManager.Instance.Highlight(erlenmeyer_low);
        }
    }

    private IEnumerator StartTask(int value)
    {
        yield return new WaitForSeconds(5f);
        taskText.text = tasks[value];
        profText.text = tasks[value];
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
        if (activeChapter && activeTask == value)
        {
            completedTasks = completedTasks + 1;
            progressBar.value = (float)completedTasks / tasks.Count;
            taskText.text = $"Aufgabe {value} erledigt!";
            profText.text = $"Aufgabe {value} erledigt!";

            StartCoroutine(StartTask(value + 1));
        }
    }

    //Task1
    public void SetGlassesClean()
    {
        CheckTask(1);
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(puffer);
            HighlightManager.Instance.StopHighlight(loesung1);
            HighlightManager.Instance.StopHighlight(erlenmeyer);
            HighlightManager.Instance.Highlight(gloves);
            HighlightManager.Instance.Highlight(glasses);
        }
        else if (highlightLabel == 0)
        {
            LowHighlightManager.Instance.StopHighlight(puffer_low);
            LowHighlightManager.Instance.StopHighlight(loesung1_low);
            LowHighlightManager.Instance.StopHighlight(erlenmeyer_low);
            LowHighlightManager.Instance.Highlight(gloves_low);
            LowHighlightManager.Instance.Highlight(glasses_low);
        }
    }

    //Task2
    public void SetClothesOff()
    {
        CheckTask(2);
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(gloves);
            HighlightManager.Instance.StopHighlight(glasses);
            HighlightManager.Instance.Highlight(button);
        }
        else if (highlightLabel == 0)
        {
            LowHighlightManager.Instance.StopHighlight(gloves_low);
            LowHighlightManager.Instance.StopHighlight(glasses_low);
            LowHighlightManager.Instance.Highlight(button_low);
        }
    }

    //Task3
    public void SetLightsOff()
    {
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(button);
        }
        else if (highlightLabel == 0)
        {
            LowHighlightManager.Instance.StopHighlight(button_low);
        }
        CheckTask(3);
    }


}


