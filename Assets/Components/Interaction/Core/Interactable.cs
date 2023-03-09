using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string interactionText = "Interact";
    [SerializeField] private float interactionRange = 2f;
    [SerializeField] private IInteractable interactable;

    private bool isInRange;
    

    private void Start()
    {
        SphereCollider sc = gameObject.AddComponent<SphereCollider>();
        sc.radius = interactionRange;
        sc.isTrigger = true;
        
        if(interactable == null)
            Debug.LogWarning("IInteractable is not set-up!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            DisplayInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isInRange = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange && interactable != null)
            interactable.Interact();
    }

    private void DisplayInteraction()
    {
        Debug.Log("I can be interacted! - " + interactionText);
    }
}
