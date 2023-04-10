using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] float yThreshold;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    void Start()
    {
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;
    }

    void Update()
    {
        if(transform.position.y > yThreshold) return;
        transform.position = spawnPosition;
        transform.rotation = spawnRotation;
    }
}
