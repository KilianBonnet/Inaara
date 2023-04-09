using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == ("Main Camera"))
            meshRenderer.enabled = false;
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.name == ("Main Camera"))
            meshRenderer.enabled = true;
    }
}
