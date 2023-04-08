using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePreparationQuestInteractor : Interactable
{
    private RacePreparationQuest quest;

    private void Start() {
        quest = GetComponent<RacePreparationQuest>();
    }


    public override void Interact()
    {
        quest.BeginQuest();
        IsTerminated = true;
    }
}
