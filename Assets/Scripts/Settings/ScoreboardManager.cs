using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
public class ScoreboardManager : MonoBehaviour
{
    public List<ScoreEntry> entries = new List<ScoreEntry>();
    public TextMeshPro scoreText;

    void Start()
    {
        entries.Add(new ScoreEntry("Anna", 123f));
        entries.Add(new ScoreEntry("Max", 200f));
        entries.Add(new ScoreEntry("Moritz", 798f));
        entries.Add(new ScoreEntry("Bob", 8923f));
        entries.Add(new ScoreEntry("Eren", 444f));

        RefreshScoreboard();

    }


    public void AddEntry(string playerName, float playerTime)
    {
        entries.Add(new ScoreEntry(playerName, playerTime));
        RefreshScoreboard();
    }

    public void RefreshScoreboard()
    {
        entries = entries.OrderBy(e => e.playerTime).ToList();
        string text = "";
        for (int i = 0; i < entries.Count; i++)
        {
            text += $"{i + 1}. {entries[i].playerName} - {entries[i].playerTime:F2} seconds\n";
        }
        scoreText.text = text;
    }
}
