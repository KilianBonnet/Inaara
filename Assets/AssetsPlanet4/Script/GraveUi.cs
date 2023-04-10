using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveUi : Interactable
{
    [SerializeField] private GameObject bookUI;
    [SerializeField] private DialogueManager dialogueManager;
    public override void Interact()
    {
        FindObjectOfType<PlayerStateManager>().UpdateState(PlayerState.IN_DIALOGUE);

        if(bookUI.activeInHierarchy) {
            IsTerminated = true;
            ShouldBeDestroyed = true;
            bookUI.SetActive(false);
            Destroy(this);
        }
        else {
            bookUI.SetActive(true);
            Invoke("StartDialogDelayed", 2f);
        }
    }

    private void StartDialogDelayed() {
        dialogueManager.Interact();
    }
    
}
