using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveQuest : Interactable
{
    public override void Interact()
    {
        IsTerminated = true;
        
        FindObjectOfType<FollowSoulQuest>().UpdateQuest(
            "Le récit de l’au-delà",
            "Inspectez la tombe de Iora."
        );

        GameObject.Find("grave-dirt").GetComponent<Interactor>().enabled = true;
    }
}
