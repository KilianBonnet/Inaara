using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAI : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float movementSpeed = .01f;
    [SerializeField] private float maxRotationAngle = 30;
    [SerializeField] private float objectiveRefreshTime = .5f;
    private float angleObjective;
    private float lastObjectiveTime;


    private ArcadeGameStateManager arcadeGameStateManager;
    private Rigidbody rb;

    void Start()
    {
        arcadeGameStateManager = FindObjectOfType<ArcadeGameStateManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        lastObjectiveTime += Time.deltaTime;
        RegenerateBestAngle();
    }

    void FixedUpdate()
    {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_GAME) return;

        float currentRotationAngle = getCurrentRotationAngle();

        if(Mathf.Abs(currentRotationAngle) > .5f)
            rb.AddForce(Vector3.back * Time.deltaTime * currentRotationAngle * movementSpeed);
            
        
        float horizontalInput = SimulateVerticalInput(currentRotationAngle);

        if(Mathf.Abs(horizontalInput) <= .2f) {
            if(Mathf.Abs(currentRotationAngle) > 1f)
            rb.MoveRotation(Quaternion.Euler(new Vector3(0, currentRotationAngle + (currentRotationAngle > 0 ? -1 : 1) * rotationSpeed * Time.deltaTime, 0)));
            return;
        }

        if(currentRotationAngle > maxRotationAngle && horizontalInput > 0) return;                      // Avoiding maxAngle overtaking
        if (currentRotationAngle < -maxRotationAngle && horizontalInput < 0) return;                    // Avoiding maxAngle overtaking
        rb.MoveRotation(Quaternion.Euler(new Vector3(0, currentRotationAngle + horizontalInput * rotationSpeed * Time.deltaTime, 0)));
    }

    private float SimulateVerticalInput(float currentRotationAngle) {
        float angleDelta = angleObjective - currentRotationAngle;
        if(Mathf.Abs(angleDelta) < 2f) return 0;
        return angleDelta > 0 ? 1 : -1;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Left Border") {
            angleObjective = Random.Range(7f, 15f);
            lastObjectiveTime = 0;
            return;
        }
        if(other.gameObject.name == "Right Border") {
            angleObjective = - Random.Range(7f, 15f);
            lastObjectiveTime = 0;
            return;
        }
    }

    private void RegenerateBestAngle() {
        if(lastObjectiveTime < objectiveRefreshTime) return;
        lastObjectiveTime = 0;
        angleObjective = CalculateBestAngle();
    }

    private float CalculateBestAngle() {
        Vector3 vehiclePosition = transform.position;
        List<Vector3> trashPositionList = new List<Vector3>();
        
        Vector3 closestVector = Vector3.zero;
        float minDistance = Mathf.Infinity;
        foreach(Trash trash in FindObjectsOfType<Trash>()) {
            Vector3 trashPosition = trash.transform.position;
            float distance = Vector3.Distance(trashPosition, vehiclePosition);

            if(trashPosition.x > vehiclePosition.x 
                && Mathf.Abs(trashPosition.z - vehiclePosition.z) < 4
                && distance < minDistance)
            {
                closestVector = trashPosition;
                minDistance = distance;
            }
        }

        if(closestVector == Vector3.zero) {
            float distanceFromMiddle = -174 - vehiclePosition.z;
            
            if(Mathf.Abs(distanceFromMiddle) > 3) {
                return (distanceFromMiddle > 0 ? -1: 1) * maxRotationAngle * .6f;
            }
            return 0;
        }

        int sign = vehiclePosition.z -closestVector.z > 0 ? -1 : 1;
        float b = Mathf.Max(Mathf.Abs((-maxRotationAngle/40) * minDistance + maxRotationAngle), 5);
        return sign * b;
    }

    private float getCurrentRotationAngle() {
         return transform.localEulerAngles.y > 300 ? transform.localEulerAngles.y - 360 : transform.localEulerAngles.y;
    }
}
