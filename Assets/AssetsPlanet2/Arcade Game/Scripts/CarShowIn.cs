using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarShowIn : MonoBehaviour
{
    private ArcadeGameManager arcadeGameManager;
    private ArcadeGameStateManager arcadeGameStateManager;

    private void Start() {
        arcadeGameStateManager = FindObjectOfType<ArcadeGameStateManager>();
        arcadeGameManager = FindObjectOfType<ArcadeGameManager>();
    }

    private void Update() {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_SHOW_IN_ANIMATION && arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_GAME) 
            return;

        if(transform.localPosition.x < -1) 
            transform.position += Vector3.right * Time.deltaTime * 30;
        else {
            arcadeGameManager.TutorialLeftRightStage();
            Destroy(this); // Removing unused component
        }
    }
}
