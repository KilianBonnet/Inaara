using UnityEngine.Events; // needed to use UnityEvent
using UnityEngine; // as usual
public class SimpleCheckpoint : MonoBehaviour
{
    public UnityEvent<CarIdentity, SimpleCheckpoint> onCheckpointEnter;

    void OnTriggerEnter(Collider collider)
    {
        // if entering object is tagged as the Player
        if (collider.GetComponent<CarIdentity>() != null)
        {
            // fire an event giving the entering gameObject and this checkpoint
            onCheckpointEnter.Invoke(collider.gameObject.GetComponent<CarIdentity>(), this);
        }
    }
}