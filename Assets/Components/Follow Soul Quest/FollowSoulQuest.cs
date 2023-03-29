using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSoulQuest : Quest
{
    [SerializeField] private GameObject[] toDisable;
    [SerializeField] private GameObject[] toEnable;
    
    public override void BeginQuest()
    {
        // Set up the text to display
        questName = "Le récit de l’au-delà";
        questDescription = "Cherchez l'ame au fond  ";
        
        // Managing quest objects
        foreach (GameObject g in toDisable) g.SetActive(false);
        foreach (GameObject g in toEnable) g.SetActive(true);
        
        
        questManager.Remove(FindObjectOfType<AltarQuest>()); // Removing old quest
        questManager.Add(this);
    }
}
