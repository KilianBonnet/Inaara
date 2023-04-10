using System.Collections;
using UnityEngine;

public class Leave : MonoBehaviour
{
    private LeaveQuest leaveQuest;
    private bool triggeredOnce = false;

    private void Start()
    {
        leaveQuest = FindObjectOfType<LeaveQuest>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggeredOnce)
        {
            if (!other.CompareTag("Player")) return;
            triggeredOnce = true;
            leaveQuest.TerminateQuest();
        }
    }
}



