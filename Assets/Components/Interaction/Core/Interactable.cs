using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [HideInInspector]
    public bool ShouldBeDestroyed; // If the object should be destroyed at the end of its execution
    
    [HideInInspector]
    public bool IsTerminated; // If the interaction is terminated

    /**
     * This method is called to interact with the script
     */
    public abstract void Interact();
}