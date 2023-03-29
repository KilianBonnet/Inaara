using UnityEngine;

public class NPCAggro : Interactable
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        
        // TODO: Lancer une animation de "bonjour"
        
        DialogueManager dialogueManager = GetComponent<DialogueManager>();
        if(dialogueManager == null) return;
        
        dialogueManager.Interact();
    }


    public override void Interact()
    {
        FindObjectOfType<ArtQuest>().BeginQuest();
        IsTerminated = true;
    }
}
