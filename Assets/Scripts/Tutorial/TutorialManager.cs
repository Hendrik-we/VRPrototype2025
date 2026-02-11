using UnityEngine;
// Hier schreibe ich meine Kommentare hin
using TMPro;
using System.Collections;
using System.Collections.Generic;




public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;

    private bool chapterActive = false;
    Dictionary<int, string> tasks = new Dictionary<int, string>()
        {
            {1, "Aufgabe 1: Setz die Schutzbrille auf und zieh die Sicherheitshandschuhe an!"},
            {2, "Aufgabe 2: Nimm den leeren Erlenmeyerkolben aus dem Regal und stell ihn auf den Tisch!"},
            {3, "Aufgabe 3: Nimm den Florenzkolben aus dem Regal und stell ihn auf den Tisch!"},
            {4, "Aufgabe 4: Entleere den Florenzkolben in den Erlenmeyerkolben!"},
            {5, "Aufgabe 5: Platziere die fertige Mischung im Analysegerät!"},
            {6, "Aufgabe 6: Stell den leeren Florenzkolben zurück ins Regal!"},
            {7, "Aufgabe 7: Setz die Brille wieder ab und zieh die Sicherheitshandschuhe aus!" },
            {8, "Tutorial abgeschlossen!"}
        };

        // selbst erlernen: ifelse, for, while, if, public/private, checktask, starttask, startchapter, publicmethods, 
        // privatemethods
        // Raum funktionieren zu machen: Befehle ausführen, siehe Whatsapp  
    public void StartChapter()
    {

        chapterActive = true; 

        taskText.text="Herzlich Willkommen im Test-Lab";

    }
}