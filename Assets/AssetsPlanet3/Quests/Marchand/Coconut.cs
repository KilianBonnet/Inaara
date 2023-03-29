using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : Interactable
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
        GetComponent<MeshRenderer>().enabled = false;
        marchandQuest.AddOneCoconut();
        IsTerminated = true;
    }
}
