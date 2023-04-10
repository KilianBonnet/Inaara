using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulQuestEnd : Interactable
{
    public override void Interact()
    {
        IsTerminated = true;
        FindObjectOfType<FollowSoulQuest>().UpdateQuest(
            "Avons nous encore le temps ?",
            "Il serait temps de rentrer, Princesse du temps."
        );

        GameObject.Find("Spaceship").GetComponent<Interactor>().enabled = true;
    }
}
