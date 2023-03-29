using System.Collections;
using UnityEngine;

public class Leave : Interactable
{
    private LeaveQuest leaveQuest;

    private void Start()
    {
        leaveQuest = FindObjectOfType<LeaveQuest>();
    }

    public override void Interact()
    {
        StartCoroutine(DelayedEnd());
    }


    public IEnumerator DelayedEnd()
    {
        yield return new WaitForSeconds(1);
        
        IsTerminated = true;
        leaveQuest.TerminateQuest();
    }
}
