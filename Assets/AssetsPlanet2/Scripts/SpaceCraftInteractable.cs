using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCraftInteractable : Interactable
{   
    [SerializeField] private GameObject[] toEnable;

    public override void Interact()
    {
        IsTerminated = true;
        FindObjectOfType<RaceQuest>().ReturnToSpacecraft();
        foreach (GameObject gameObject in toEnable) gameObject.SetActive(true);
    }
}
