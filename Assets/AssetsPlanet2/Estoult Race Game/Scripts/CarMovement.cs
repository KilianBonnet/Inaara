using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    private float forwardMoveSpeed;
    [SerializeField]
    private float backwardMoveSpeed;
    [SerializeField]
    private float steerSpeed;
    
    private Rigidbody rg;

    private Vector2 input;

    private void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    public void SetInputs(Vector2 input)
    {
        this.input = input;
    }
    
    void FixedUpdate() // Apply physics here
    {
        // Accelerate
        float speed = input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        if (input.y == 0) speed = 0;
        rg.AddForce(transform.forward * speed, ForceMode.Acceleration);
        // Steer
        float rotation = input.x * steerSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, rotation, 0, Space.World);
    }
}
