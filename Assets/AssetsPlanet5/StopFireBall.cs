using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFireBall : MonoBehaviour
{
    FireBallGenerator fire;
    public void OnTriggerEnter() {
        fire = FindObjectOfType<FireBallGenerator>();
        fire.isFire = false;
    }
}
