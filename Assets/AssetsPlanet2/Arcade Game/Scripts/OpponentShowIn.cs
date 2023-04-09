using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentShowIn : MonoBehaviour
{

    private void Update() {
        if(transform.localPosition.x < -1) 
            transform.position += Vector3.right * Time.deltaTime * 30;
        else 
            Destroy(this); // Removing unused component
    }
}
