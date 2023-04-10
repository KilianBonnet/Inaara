using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCraftInteractable : Interactable
{   public override void Interact()
    {
        IsTerminated = true;
        FindObjectOfType<RaceQuest>().ReturnToSpacecraft();
    }
}
