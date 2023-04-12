using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApoAggro : Interactable
{
    private Animator mAnimator;
    public Transform target;
    private bool triggeredOnce = false;
    public bool isApo = true;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!triggeredOnce)
        {
            if(!other.CompareTag("Player")) return;
            triggeredOnce = true;
            // TODO: Lancer une animation de "bonjour"
        
            DialogueManager dialogueManager = GetComponent<DialogueManager>();
            if(dialogueManager == null) return;
        
            dialogueManager.Interact();
            RunAnimation();
        }
    }


    public override void Interact()
    {
        IsTerminated = true;
    }

    public void RunAnimation()
    {
        transform.LookAt(target, Vector3.up);
        if (mAnimator != null&&isApo)
        {
            mAnimator.SetTrigger("enterZone");
        }
    }
}
