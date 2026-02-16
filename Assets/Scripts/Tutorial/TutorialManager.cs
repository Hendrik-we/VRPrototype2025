using UnityEngine;
// Hier schreibe ich meine Kommentare hin
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;




public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public ChapterManager chapterManager;
    public TeleportManager teleportManager;
    public Transform startPoint;
    public Slider progressBar;

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
            StartCoroutine(StartTask(value + 1));
        }
    }

    public void SetGlovesOn()
    {
        CheckTask(1);
    }

    public void ErlenmeyerPlaced()
    {
        CheckTask(2); 
    }

    public void ErlenmeyerFilled()
    {
        CheckTask(3);
    }

    public void ErlenmeyerAnalyzed()
    {
        CheckTask(4);
    }

    public void SetGlovesOff()
    {
        CheckTask(5);
    }

    public void FinishTutorial()
    {
        CheckTask(6);
    }





}