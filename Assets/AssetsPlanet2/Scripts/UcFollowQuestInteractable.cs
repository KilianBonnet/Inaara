using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UcFollowQuestInteractable : Interactable
{
    private RacePreparationQuest racePreparationQuest;
    private UnityChanFollow unityChanFollow;

    private void Start() {
        racePreparationQuest = FindObjectOfType<RacePreparationQuest>();
        unityChanFollow = FindObjectOfType<UnityChanFollow>();
    }

    public override void Interact()
    {
        IsTerminated = true;
        racePreparationQuest.UpdateUpdateQUest(
            "Une sensation de vitesse",
            "Suivez Unity Chan : la princesse du groupe Plouf et organisatrice intérimaire de cette course."
        );
        unityChanFollow.Interact();
    }
}
