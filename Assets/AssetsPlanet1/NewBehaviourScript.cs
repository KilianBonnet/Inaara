using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Interactable
{
    //il s'appelle machinquest interactble
    // Start is called before the first frame update
    public override void Interact()
    {
        FindObjectOfType<MachinQuest>().BeginQuest();
        ShouldBeDestroyed = true;
        IsTerminated = true;
    }
}
