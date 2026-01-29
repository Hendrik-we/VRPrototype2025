using UnityEngine;
using TMPro;
using System.Collections;

public class ReagenzManager : MonoBehaviour
{
    public GameObject erlenmeyer;
    public GameObject liquid;
    public TextMeshProUGUI reagenzText;
    public TextMeshProUGUI reactionText;
    public TaskManager2 taskManager2;


    private bool isReacting = false;
    private float reactionTime = 35f;
    private bool hasLiquid = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == erlenmeyer && !hasLiquid)
        {
            hasLiquid = true;
            liquid.SetActive(true);
            reagenzText.text = "Säure X - gekühlt";
            taskManager2.SetGlassFilled();
            if (!isReacting)
            {
                StartCoroutine(StartReaction());
            }
        }
    }



    private IEnumerator StartReaction()
    {
        isReacting = true;

        float timer = 0f;

        while (timer < reactionTime)
        {
            
            float perc = timer / reactionTime;
            reactionText.text = $"Reaktion läuft... {perc * 100:F0}%";
            timer += 1f;
            yield return new WaitForSeconds(1f);

        }

        reactionText.text = "Reaktion abgeschlossen!";
        taskManager2.SetReactionDone();
    }
}
