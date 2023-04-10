using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveQuest : Quest
{
    void Awake()
    {
        StartCoroutine(StartQuest());
    }
    
    public override void BeginQuest()
    {
        questName = "De nouvelles aventures";
        questDescription = "Retournez jusqu'à votre vaisseau";
        questManager.Add(this);
    }
    public void TerminateQuest()
    {
        questManager.Remove(this);
    }
    private IEnumerator StartQuest()
    {
        yield return new WaitForSeconds(1);
        BeginQuest();
    }
}