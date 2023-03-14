using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipNoise : MonoBehaviour
{
    [SerializeField] private float xPositionRange = 1;
    [SerializeField] private float yPositionRange = 2f;
    
    private Vector3 initialPosition;

    private float positionSpeed;
    private Vector3 positionObjective;

    private float rotationSpeed;
    private Quaternion rotationObjective;

    private void Start()
    {
        Transform t = transform;
        initialPosition = t.position;
        GenerateNewPositionObjective();
    }
    
    private void Update()
    {
        if(Vector3.Distance(transform.position, positionObjective) <= .1f) GenerateNewPositionObjective();
        MoveToObjective();
    }

    private void GenerateNewPositionObjective()
    {
        positionObjective = new Vector3(
            initialPosition.x - xPositionRange + Random.Range(0f, 2 * xPositionRange),
            initialPosition.y - yPositionRange + Random.Range(0f, 2 * yPositionRange),
            initialPosition.z
        );

        positionSpeed = Random.Range(.5f, .8f);
    }

    private void MoveToObjective()
    {
        Vector3 posDelta = positionObjective - transform.position;
        transform.position +=  positionSpeed * Time.deltaTime * posDelta.normalized;
    }
}
