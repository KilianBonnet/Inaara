using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    public UnityEvent<Vector2> onInput;
    
    private void Update()
    {
        // Listening keyboard input
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        
        // Convert keyboard input to a normalized 2 dimensional vector
        Vector2 direction = new Vector2(inputX, inputY).normalized;
        
        // Invoking the new direction
        onInput.Invoke(direction);
    }
}
