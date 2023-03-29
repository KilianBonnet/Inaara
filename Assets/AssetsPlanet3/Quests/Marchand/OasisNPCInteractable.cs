using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OasisNPCInteractable : Interactable
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
        marchandQuest.ChangeObjective("Ramasser les noix de coco autour de l'Oasis 0/5");
        foreach (Coconut coconut in GameObject.FindObjectsOfType<Coconut>())
        {
            coconut.GetComponent<Interactor>().enabled = true;
        }
        foreach (Transform zoom in GameObject.Find("ZoomCoconuts").transform)
        {
            zoom.GetComponent<BoxCollider>().enabled = true;
            zoom.GetComponent<ZoomCamera>().enabled = true;
        }
        IsTerminated = true;
    }
}
