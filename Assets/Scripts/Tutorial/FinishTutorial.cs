using UnityEngine;

public class FinishTutorial : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public void Finish()
    {
        tutorialManager.FinishTutorial();
    }
}
