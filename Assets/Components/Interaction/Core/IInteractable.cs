public interface IInteractable
{
    /**
     * This method is called when a layer press the key to interact with the element.
     */
    public void Interact();
    
    /**
     * This method is called to check if the interaction is terminated and should be destroyed.
     */
    public bool ShouldBeDestroyed();
}