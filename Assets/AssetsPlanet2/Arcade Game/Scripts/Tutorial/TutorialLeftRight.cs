using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLeftRight : MonoBehaviour
{
    private int leftCounter;
    private int rightCounter;

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput > .2f) leftCounter++;
        else if(horizontalInput < -.2f) rightCounter++;
        OnTutorialCompleted();
    }

    private void OnTutorialCompleted() {
        if(leftCounter < 100 && rightCounter < 100) return;
        FindObjectOfType<ArcadeGameManager>().TutorialAvoid();
        Destroy(this);
    }
}
