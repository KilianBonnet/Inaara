using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAI : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float movementSpeed = .01f;
    [SerializeField] private float maxRotationAngle = 30;
    private float angleObjective;
    private float lastObjectiveTime;


    private ArcadeGameStateManager arcadeGameStateManager;
    private Rigidbody rb;

    void Start()
    {
        arcadeGameStateManager = FindObjectOfType<ArcadeGameStateManager>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_GAME) return;

        float currentRotationAngle = transform.localEulerAngles.y > 300 ?                               // "Fixing" 360 angle issue
        transform.localEulerAngles.y - 360 : transform.localEulerAngles.y;

        if(Mathf.Abs(currentRotationAngle) > .5f)
            rb.AddForce(Vector3.back * Time.deltaTime * currentRotationAngle * movementSpeed);
            
        float horizontalInput = SimulateVerticalInput(currentRotationAngle);

        if(Mathf.Abs(horizontalInput) <= .2f) {
            if(Mathf.Abs(currentRotationAngle) > 1f)
            rb.MoveRotation(Quaternion.Euler(new Vector3(0, currentRotationAngle + (currentRotationAngle > 0 ? -.5f : .5f) * rotationSpeed * Time.deltaTime, 0)));
            return;
        }

        if(currentRotationAngle > maxRotationAngle && horizontalInput > 0) return;                      // Avoiding maxAngle overtaking
        if (currentRotationAngle < -maxRotationAngle && horizontalInput < 0) return;                    // Avoiding maxAngle overtaking
        rb.MoveRotation(Quaternion.Euler(new Vector3(0, currentRotationAngle + horizontalInput * rotationSpeed * Time.deltaTime, 0)));
    }

    private float SimulateVerticalInput(float currentRotationAngle) {
        lastObjectiveTime += Time.fixedDeltaTime;
        float angleDelta = angleObjective - currentRotationAngle;
        if(Mathf.Abs(angleDelta) < .3f) {
            if(lastObjectiveTime < .7f) return 0;

            lastObjectiveTime = 0;
            int sign = Random.Range(0, 2) == 0 ? -1 : 1;
            angleObjective = sign * Random.Range(5f, 15f);
            Debug.Log("New objective is : " + angleObjective);
            angleDelta = angleObjective - currentRotationAngle;
        }

        return angleDelta > 0 ? .9f : -.9f;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Left Border") {
            angleObjective = Random.Range(5f, 15f);
            lastObjectiveTime = 0;
            return;
        }
        if(other.gameObject.name == "Left Border") {
            angleObjective = - Random.Range(5f, 15f);
            lastObjectiveTime = 0;
            return;
        }

    }
}
