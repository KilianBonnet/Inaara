using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NoiseGenerator : MonoBehaviour
{
    [SerializeField] private AudioClip[] noise;
    [SerializeField] private float minGap = 5;
    [SerializeField] private float maxGap = 20;
    private AudioSource audioSource;
    private float timer;

    private void Start()
    {
        if (noise.Length == 0)
        {
            Debug.LogError("No AudioClip found !");
            Destroy(this);
        }

        timer = 5;  
        audioSource = GetComponent<AudioSource>();
            
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }
        
        audioSource.PlayOneShot(noise[Random.Range(0, noise.Length)]);
        timer = Random.Range(minGap, maxGap);
    }
}
