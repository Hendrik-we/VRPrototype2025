using UnityEngine;
// Hier schreibe ich meine Kommentare hin
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;




public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public TextMeshPro profText;
    public ChapterManager chapterManager;
    public TeleportManager teleportManager;
    public Transform startPoint;
    public Slider progressBar;
    public HighlightManager highlightManager;
    public int highlightLabel;

    public HighlightableObject gloves;
    public HighlightableObject erlenmeyer;
    public HighlightableObject florenz;
    public HighlightableObject analysis;
    public HighlightableObject button;

    private int activeTask = 0;
    private int completedTasks = 0;
    private bool chapterActive = false;
    
    Dictionary<int, string> tasks = new Dictionary<int, string>()
        {
            {1, "Aufgabe 1: Zieh die Sicherheitshandschuhe an! Klicke dafür auf die gelben Handschuhe auf dem Schrank!"},
            {2, "Aufgabe 2: Nimm den leeren Erlenmeyerkolben aus dem Regal und stell ihn auf den Tisch!"},
            {3, "Aufgabe 3: Entleere den Florenzkolben in den Erlenmeyerkolben!"},
            {4, "Aufgabe 4: Platziere die fertige Mischung im Analysegerät!"},
            {5, "Aufgabe 5: Zieh die Sicherheitshandschuhe aus!" },
            {6, "Schau dich im Labor um und lerne die verschiedenen Geräte kennen! Wenn du damit fertig bist, starte das Szenario mit dem großen grünen Knopf an der Wand!"},
            {7, "Tutorial abgeschlossen!"}
        };

 
    public void StartChapter()
    {
        teleportManager.TeleportTo(startPoint);
        chapterActive = true; 
        taskText.text = "Laborschulung - Tutorial: Einführung in die Laborausrüstung";
        profText.text = "Laborschulung - Tutorial: Einführung in die Laborausrüstung";
        StartCoroutine(StartTask(1));
        progressBar.value = 0;
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.Highlight(gloves);
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
            chapterActive = false;
            chapterManager.CheckTutorial();
        }
    }

    private void CheckTask(int value)
    {
        if (chapterActive && activeTask == value)
        {
            completedTasks = completedTasks + 1;
            progressBar.value = (float)completedTasks / tasks.Count;
            taskText.text = $"Aufgabe {value} erledigt!";
            profText.text = $"Aufgabe {value} erledigt!";
            StartCoroutine(StartTask(value + 1));
        }
    }

    public void SetGlovesOn()
    {
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(gloves);
            HighlightManager.Instance.Highlight(erlenmeyer);
        }
        CheckTask(1); 

    }

    public void ErlenmeyerPlaced()
    {
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(erlenmeyer);
            HighlightManager.Instance.Highlight(florenz);
        }
        CheckTask(2);

    }

    public void ErlenmeyerFilled()
    {
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(florenz);
            HighlightManager.Instance.Highlight(analysis);
        }
        CheckTask(3);
    }

    public void ErlenmeyerAnalyzed()
    {
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(analysis);
            HighlightManager.Instance.Highlight(gloves);
        }
        CheckTask(4);

    }

    public void SetGlovesOff()
    {
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(gloves);
            HighlightManager.Instance.Highlight(button);
        }
        CheckTask(5);
    }

    public void FinishTutorial()
    {
        if (highlightLabel == 1)
        {
            HighlightManager.Instance.StopHighlight(button);
        }
        CheckTask(6);
    }


}