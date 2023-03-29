using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeilleHomeQuestInteractible : Interactable
{
    public VeilleHomeQuest VeilleHomeQuest;
    // Start is called before the first frame update
    public override void Interact()
    {
        FindObjectOfType<VeilleHomeQuest>().BeginQuest();
        ShouldBeDestroyed = true;
        IsTerminated = true;
    }
}
