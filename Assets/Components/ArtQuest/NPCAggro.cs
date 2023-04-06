using UnityEngine;

public class NPCAggro : Interactable
{
    private Animator mAnimator;
    public Transform target;
    private bool triggeredOnce = false;


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
        FindObjectOfType<ArtQuest>().BeginQuest();
        IsTerminated = true;
    }

    public void RunAnimation()
    {
        if (mAnimator != null)
        {
            transform.LookAt(target, Vector3.up);
            mAnimator.SetTrigger("enterZone");
        }
    }
}
