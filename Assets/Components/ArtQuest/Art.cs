using System.Collections;
using UnityEngine;

public class Art : Interactable
{
    public bool hasBeenWatched;
    private ArtQuest artQuest;

    private void Start()
    {
        IsTerminated = false;
        artQuest = FindObjectOfType<ArtQuest>();
    }

    public override void Interact()
    {
        StartCoroutine(DelayedEnd());
    }


    public IEnumerator DelayedEnd()
    {
        yield return new WaitForSeconds(1);
        
        hasBeenWatched = true;
        IsTerminated = true;
        artQuest.UpdateQuest();
    }
}
