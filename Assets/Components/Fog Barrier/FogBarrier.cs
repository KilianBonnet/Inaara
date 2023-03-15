using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogBarrier : MonoBehaviour
{
    [SerializeField] private float maxRange;
    [SerializeField] private float maxFogDensity;
    [SerializeField] Transform teleportPoint;

    private float baseFogDensity;
    private Transform playerPosition;
    private DialogueManager dialogueManager;
    
    private void Start()
    {
        baseFogDensity = RenderSettings.fogDensity;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        dialogueManager = GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(playerPosition.position, transform.position);
        if (distance < maxRange) RenderSettings.fogDensity = maxFogDensity - (maxFogDensity * distance / maxRange) + baseFogDensity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        RenderSettings.fogDensity = baseFogDensity;
        other.gameObject.transform.position = teleportPoint.position;
        dialogueManager.Interact();
    }
}
