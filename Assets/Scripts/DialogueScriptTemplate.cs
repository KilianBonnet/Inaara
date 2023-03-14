using System;
using UnityEngine;

public class DialogueScriptTemplate : Interactable
{
    private float timer;
    private bool isActive;

    public override void Interact()
    {
        Debug.Log("Interaction script is starting!");
        timer = 0;
        ShouldBeDestroyed = false;
        IsTerminated = false;
        isActive = true;
    }

    private void Update()
    {
        if(!isActive) return;
        timer += Time.deltaTime;
        if (timer > 6f)
        {
            Debug.Log("Interaction script is terminated!");
            IsTerminated = true;
            isActive = false;
        } 
    }
}
