using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidNPCInteractable : Interactable
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
        marchandQuest.ChangeObjective("Trouver l'Apo proche de l'Obélisque au sud");
        marchandQuest.ChangeName("Acheter un super générateur (80/120)");
        marchandQuest.ActiveObeliskNPC();
        IsTerminated = true;
    }
}
