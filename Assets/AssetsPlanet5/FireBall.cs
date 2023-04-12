using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float traveledDistance;
    public GameObject respawnPoint;
    public GameObject prefabExplosion;

    void Update()
    {
        float toTravel = Time.deltaTime * Random.Range(10f, 20f);
        traveledDistance += toTravel;
        transform.Translate(Vector3.left * toTravel);
        if (traveledDistance > 150) {
            GameObject ball = Instantiate(prefabExplosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        } 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        GameObject ball = Instantiate(prefabExplosion, transform.position, transform.rotation);

        other.gameObject.transform.position = respawnPoint.transform.position;
        other.gameObject.transform.rotation = respawnPoint.transform.rotation;

        Destroy(this.gameObject);
    }
}
