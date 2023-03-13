using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipNoise : MonoBehaviour
{
    /*[SerializeField] private float xRotationRange = 5;
    [SerializeField] private float ZRotationRange = 5;*/
    [SerializeField] private float xPositionRange = .2f;
    [SerializeField] private float yPositionRange = .2f;
    
    private Vector3 initialPosition;
    private float moveSpeed;
    private Vector3 positionObjective;

    private void Start()
    {
        initialPosition = transform.position;
        GenerateNewNoise();
    }
    
    private void Update()
    {
        if(Vector3.Distance(transform.position, positionObjective) <= .1f) GenerateNewNoise();
        MoveToObjective();
    }

    private void GenerateNewNoise()
    {
        positionObjective = new Vector3(
            initialPosition.x - xPositionRange + Random.Range(0f, 2 * xPositionRange),
            initialPosition.y - yPositionRange + Random.Range(0f, 2 * yPositionRange),
            initialPosition.z
        );
        moveSpeed = Random.Range(.1f, .2f);
    }

    private void MoveToObjective()
    {
        Vector3 v = positionObjective - transform.position;
        transform.position +=  moveSpeed * Time.deltaTime * v.normalized;
    }
}
