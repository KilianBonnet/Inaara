using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallTrigger : MonoBehaviour
{
    FireBallGenerator fireBallGenerator;

    void OnTriggerEnter(Collider inaara) {
        fireBallGenerator = FindObjectOfType<FireBallGenerator>();
        fireBallGenerator.fireBallLaunch();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
