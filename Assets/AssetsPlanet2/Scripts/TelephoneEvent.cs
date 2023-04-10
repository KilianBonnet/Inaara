using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneEvent : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private bool alreadyInteracted;

    private void Start() {
        dialogueManager = GetComponent<DialogueManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if(alreadyInteracted || !other.gameObject.CompareTag("Player")) return;
        
        dialogueManager.Interact();
        alreadyInteracted = true;
    }
}
