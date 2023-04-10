using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceQuestInteractable : Interactable
{
    private RaceQuest raceQuest;

    private void Start() {
        raceQuest = FindObjectOfType<RaceQuest>();
    }

    public override void Interact()
    {
        IsTerminated = true;
        raceQuest.BeginQuest();
    }
}
