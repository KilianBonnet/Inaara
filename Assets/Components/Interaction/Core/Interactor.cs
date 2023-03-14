using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] public string interactionText = "Interact";
    [SerializeField] private float interactionRange = 2f;
    
    private Interactable interactable;
    private InteractionUI interactionUI;
    
    private PlayerStateManager playerStateManager;

    /**
     * Create a trigger zone around the object to detect collision with player
     */
    private void Start()
    {
        // Create a trigger collider zone
        SphereCollider sc = gameObject.AddComponent<SphereCollider>();
        sc.radius = interactionRange;
        sc.isTrigger = true;

        // Find the interactionUI
        GameObject interactionUIGameObject = GameObject.Find("Interaction UI");
        if(interactionUIGameObject == null)
        {
            Debug.LogError("Can not find Interaction UI game object!");
            Destroy(this); // Self-destroy
        }
        interactionUI = interactionUIGameObject.GetComponent<InteractionUI>();
        if(interactionUI == null)
        {
            Debug.LogError("Can not find InteractionUI component in Interaction UI!");
            Destroy(this); // Self-destroy
        }

        // Find the associated interaction
        if ((interactable = GetComponent<Interactable>()) == null)
        {
            Debug.LogError("Game object has no IInteractable component!");
            Destroy(this); // Self-destroy
        }
        
        
        // Find the Player State Manager
        playerStateManager = FindObjectOfType<PlayerStateManager>();
        if (playerStateManager == null)
        {
            Debug.LogError("Cannot find object of type PlayerStateManager!");
            Destroy(this); // Self-destroy
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) interactionUI.Add(this);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) interactionUI.Remove(this);
    }
    
    private void Update()
    {
        if (interactable.IsTerminated && interactable.ShouldBeDestroyed)
        {
            Destroy(interactable); // Destroy the interactable that should be destroyed
            
            // Check if there is others interactable to display
            if ((interactable = GetComponent<Interactable>()) == null)
            {
                interactionUI.Remove(this);
                Destroy(this);
            }
        }
    }

    public void OnInteract()
    {
        interactable.Interact();
    }
}
