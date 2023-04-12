using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchandNPCInteractable : Interactable
{

    private MarchandQuest marchandQuest;

    // Start is called before the first frame update
    void Start()
    {
        marchandQuest = FindObjectOfType<MarchandQuest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        marchandQuest.ChangeNameAndObjective("Argent de poche", "Aller voir l'Oasis au nord-ouest");
        marchandQuest.ActiveOasisNPC();
        IsTerminated = true;
    }
}
