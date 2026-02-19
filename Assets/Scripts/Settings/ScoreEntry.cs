using UnityEngine;

public class ScoreEntry : MonoBehaviour
{
    public string playerName;
    public float playerTime;

    public ScoreEntry(string playerName, float time)
    {
        this.playerName = playerName;
        this.playerTime = time;
    }

}
