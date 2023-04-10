using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceQuest : Quest
{
    // Cameras
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera arcadeCamera;

    [Tooltip("Game objects to disable during the quest")]
    [SerializeField] private GameObject[] toDisable;

    [Tooltip("Game objects to enable during the quest")]
    [SerializeField] private GameObject[] toEnable;

    public override void BeginQuest()
    {
        questName = "Une course viruelle";
        questDescription = "Suivez les instruction de Unity Chan.";
        questManager.Add(this);

        mainCamera.enabled = false;
        arcadeCamera.enabled = true;

        foreach(var gameObject in toDisable) gameObject.SetActive(false);
        foreach(var gameObject in toEnable) gameObject.SetActive(true);
    }

    public void FinishRace() {
        questName = "Une course viruelle";
        questDescription = "Retournez voir Unity Chan.";
        questManager.Remove(this);
        questManager.Add(this);

        mainCamera.enabled = true;
        arcadeCamera.enabled = false;

        foreach(var gameObject in toDisable) gameObject.SetActive(true);
        GameObject.Find("Race Game End Dialogue").GetComponent<Interactor>().enabled = true;
    }

    public void ReturnToSpacecraft() {
        questName = "Un repos bien mérité";
        questDescription = "Retournez au vaisseau";
        questManager.Remove(this);
        questManager.Add(this);
    }
}
