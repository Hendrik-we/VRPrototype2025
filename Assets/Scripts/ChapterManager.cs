using UnityEngine;

public class ChapterManager : MonoBehaviour
{

    public TaskManager taskManager1;
    public TaskManager2 taskManager2;
    public TaskManager3 taskManager3;

    void Start()
    {
        taskManager1.StartChapter();
    }

    public void CheckChapter1()
    {
        StartChapter2();
    }

    private void StartChapter2()
    {
        taskManager2.StartChapter();
    }

    public void CheckChapter2()
    {
        StartChapter3();
    }

    private void StartChapter3()
    {
        taskManager3.StartChapter();
    }

    public void CheckChapter3()
    {
        return;
    }

}