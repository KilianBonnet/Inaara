using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UcFollowSecondPath : Interactable
{
    private UnityChanFollow unityChanFollow;
    private RacePreparationQuest quest;

    private void Start() {
        unityChanFollow = FindObjectOfType<UnityChanFollow>();
        quest = FindObjectOfType<RacePreparationQuest>();
    }

    public override void Interact()
    {
        IsTerminated = true;
        unityChanFollow.StartSecondPath();
        quest.UpdateUpdateQUest(
            "Une sensation de vitesse",
            "Suivez Unity Chan en traversant les textures ??!!"
        );
    }
}
