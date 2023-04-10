using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeInputsManager : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float movementSpeed = .01f;
    [SerializeField] private float maxRotationAngle = 30;


    private ArcadeGameManager arcadeGameManager;
    private ArcadeGameStateManager arcadeGameStateManager;
    private Rigidbody rb;

    void Start()
    {
        arcadeGameStateManager = FindObjectOfType<ArcadeGameStateManager>();
        arcadeGameManager = FindObjectOfType<ArcadeGameManager>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(arcadeGameStateManager.arcadeGameState == ArcadeGameState.LOADING) return; // If the game is loading, do nothing

        if(arcadeGameStateManager.arcadeGameState == ArcadeGameState.IN_START_SCREEN && Input.GetKeyDown(KeyCode.Return))
            arcadeGameManager.StartGame();

    }

    void FixedUpdate()
    {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_GAME && arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_TUTORIAL) 
            return;

        float currentRotationAngle = transform.localEulerAngles.y > 300 ?                               // "Fixing" 360 angle issue
        transform.localEulerAngles.y - 360 : transform.localEulerAngles.y;

        if(Mathf.Abs(currentRotationAngle) > .5f)
            rb.AddForce(Vector3.back * Time.deltaTime * currentRotationAngle * movementSpeed);
            
        float horizontalInput = Input.GetAxis("Horizontal");

        if(Mathf.Abs(horizontalInput) <= .2f) {
            if(Mathf.Abs(currentRotationAngle) > 1f)
            rb.MoveRotation(Quaternion.Euler(new Vector3(0, currentRotationAngle + (currentRotationAngle > 0 ? -.5f : .5f) * rotationSpeed * Time.deltaTime, 0)));
            return;
        }

        if(currentRotationAngle > maxRotationAngle && horizontalInput > 0) return;                      // Avoiding maxAngle overtaking
        if (currentRotationAngle < -maxRotationAngle && horizontalInput < 0) return;                    // Avoiding maxAngle overtaking
        rb.MoveRotation(Quaternion.Euler(new Vector3(0, currentRotationAngle + horizontalInput * rotationSpeed * Time.deltaTime, 0)));
    }
}
