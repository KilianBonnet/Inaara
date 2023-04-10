using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInteraction : Interactable
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
        GetComponent<Interactor>().interactionText = "Décoller";
        marchandQuest.GetComponent<AudioSource>().Play();
        marchandQuest.FinishQuest();
        IsTerminated = true;
    }
}
