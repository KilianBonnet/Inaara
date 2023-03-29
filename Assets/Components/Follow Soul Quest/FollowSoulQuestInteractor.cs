using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSoulQuestInteractor : Interactable
{
    private FollowSoulQuest followSoulQuest;
    
    private void Start()
    {
        followSoulQuest = FindObjectOfType<FollowSoulQuest>();
    }

    public override void Interact()
    {
        followSoulQuest.BeginQuest();
        
        ShouldBeDestroyed = true;
        IsTerminated = true;
    }
}
