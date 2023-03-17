using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarQuestInteractable : Interactable
{
    public GameObject[] toDisable;
    private AltarQuest altarQuest;

    private void Start()
    {
        IsTerminated = true;
        altarQuest = GetComponent<AltarQuest>();
    }

    public override void Interact()
    {
        foreach (GameObject g in toDisable) g.SetActive(false);
        altarQuest.BeginQuest();
    }
}
