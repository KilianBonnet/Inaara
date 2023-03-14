using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Tooltip("If the object should be destroyed at the end of its execution")]
    public bool ShouldBeDestroyed;
    
    [HideInInspector]
    public bool IsTerminated; // If the interaction is terminated

    /**
     * This method is called to interact with the script
     */
    public abstract void Interact();
}