using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInteraction : Interactable
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        GetComponent<Interactor>().interactionText = "Décoller";
        IsTerminated = true;
    }
}
