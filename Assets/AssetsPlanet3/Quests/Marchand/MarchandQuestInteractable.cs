using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchandQuestInteractable : Interactable
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
        marchandQuest.ChangeObjective("Parler au marchand");
        IsTerminated = true;
    }
}
