using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLeftRight : MonoBehaviour
{
    private bool leftCheck;
    private bool rightCheck;
    private bool tutorialCompleted;

    private void Update() {
        
        float horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput > .6f) leftCheck = true;
        else if(horizontalInput < -.6f) rightCheck = true;

        if(!leftCheck || !rightCheck || tutorialCompleted) return;
        tutorialCompleted = true;
        Invoke("OnTutorialCompleted", 3);
    }

    private void OnTutorialCompleted() {
        FindObjectOfType<ArcadeGameManager>().TutorialAvoid();
        Destroy(this);
    }
}
