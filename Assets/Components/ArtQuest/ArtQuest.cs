using System;
using UnityEngine;

public class ArtQuest : Quest
{
    private Art[] arts;
    private LeaveMuseum leaveMuseum;

    private void Awake()
    {
        arts = FindObjectsOfType<Art>();
        leaveMuseum = FindObjectOfType<LeaveMuseum>();
    }

    public override void BeginQuest()
    {
        questName = "Une visite au musée";
        questDescription = "Contemplez les oeuvres (0/" + arts.Length + ")";
        questManager.Add(this);
    }


    public void UpdateQuest()
    {
        int nbWatchedArt = 0;
        foreach (Art art in arts) if (art.hasBeenWatched) nbWatchedArt++;

        if (nbWatchedArt == arts.Length) TerminateQuest();
        else
        {
            questDescription = "Contemplez les oeuvres (" + nbWatchedArt + " /" + arts.Length + ")";
            questManager.Refresh(this);
        }
    }

    private void TerminateQuest()
    {
        questManager.Remove(this);
        leaveMuseum.canLeave = true;
        foreach(Transform child in GameObject.Find("EnterSpaceship").transform) child.gameObject.SetActive(true);
    }
    
}
