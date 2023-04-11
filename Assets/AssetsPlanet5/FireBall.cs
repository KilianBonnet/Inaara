using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float traveledDistance;

    void Update()
    {
        float toTravel = Time.deltaTime * Random.Range(10f, 20f);
        traveledDistance += toTravel;
        transform.position += Vector3.left * toTravel;
        if (traveledDistance > 100) Destroy(this.gameObject);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Car")) return;
        FindObjectOfType<ArcadeGameManager>().OnHit(other.gameObject);
        Destroy(this.gameObject);
    }*/
}
