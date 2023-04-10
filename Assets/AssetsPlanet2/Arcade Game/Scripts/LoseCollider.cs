using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private ArcadeGameManager arcadeGameManager;

    void Start()
    {
        arcadeGameManager = FindObjectOfType<ArcadeGameManager>();
    }

    private void OnTriggerEnter(Collider other) {
        arcadeGameManager.OnLoseTriggered(other.transform);
    }

}
