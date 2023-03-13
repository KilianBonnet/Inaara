using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetBehaviour : MonoBehaviour
{
    private float speed;
    private float travelDistance;
    
    void Start()
    {
        speed = Random.Range(.1f, .2f);
        float size = Random.Range(1, 3);
        transform.localScale = new Vector3(size, size, size);
    }

    private void LateUpdate()
    {
        travelDistance += Time.fixedTime * speed;
        transform.position += Time.fixedTime * speed * Vector3.left;
        if(travelDistance > 1000) Destroy(gameObject);
    }
}
