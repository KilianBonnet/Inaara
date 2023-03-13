using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;
    [SerializeField] private float YSpawnRange = 200f;
    [SerializeField] private float ZSpawnRange = 50f;
    
    private float timer;

    private void Start()
    {
        timer = 0;
    }
    
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }

        int planetIndex = Random.Range(0, planets.Length);

        Vector3 generatorPosition = transform.position;
        float y = generatorPosition.y - YSpawnRange + Random.Range(0, YSpawnRange);
        float z = generatorPosition.z - ZSpawnRange + Random.Range(0, ZSpawnRange);
        Instantiate(planets[planetIndex], new Vector3(generatorPosition.x, y, z), new Quaternion());
        
        timer = Random.Range(10, 15);
    }
}
