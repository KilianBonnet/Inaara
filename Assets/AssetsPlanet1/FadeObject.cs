using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    public float fadeDistance = 5f; // Distance at which object is completely transparent
    public float maxAlpha = 1f; // Maximum alpha value of the object
    private Rigidbody targetRigidbody;
    private Material material1;
    private Material material2;
    public float threshold = 1f; // Threshold below which the object's collider is disabled

    private void Start()
    {
        // Get the materials of the object
        targetRigidbody=GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Rigidbody>();
        material1 = GetComponent<Renderer>().material;
        material2 = GetComponent<Renderer>().materials[1]; 
    }

    private void Update()
    {
        // Calculate the distance between the camera and the object
        float distance = Vector3.Distance(transform.position, targetRigidbody.position);

        // Calculate the alpha value based on the distance
        float alpha = Mathf.Clamp01(distance / fadeDistance);

        // Set the alpha value of the materials
        Color color = material1.color;
        color.a = alpha * maxAlpha;
        material1.color = color;

        Color color2 = material2.color;
        color2.a = alpha * maxAlpha;
        material2.color = color2;
        
        if (alpha < threshold)
        {
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            GetComponent<Collider>().enabled = true;
        }
    }
}