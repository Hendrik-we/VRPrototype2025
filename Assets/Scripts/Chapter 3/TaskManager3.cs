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
    public HighlightManager highlightManager;
    public int highlightLabel;


    public HighlightableObject puffer;
    public HighlightableObject erlenmeyer;
    public HighlightableObject loesung1;
    public HighlightableObject gloves;
    public HighlightableObject glasses;
    public HighlightableObject button;


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
        StartCoroutine(StartTask(1));
        progressBar.value = 0;
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.Highlight(puffer);
            HighlightManager.Instance.Highlight(loesung1);
            HighlightManager.Instance.Highlight(erlenmeyer);
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
    }

    //Task3
    public void SetLightsOff()
    {
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(button);
        }
        CheckTask(3);
    }


}


