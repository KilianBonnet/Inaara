using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeilleHomeQuestInteractible : Interactable
{
    public Quest veilleHomeQuest;
    // Start is called before the first frame update
    public override void Interact()
    {
        veilleHomeQuest.BeginQuest();
        ShouldBeDestroyed = true;
        IsTerminated = true;
    }
}
