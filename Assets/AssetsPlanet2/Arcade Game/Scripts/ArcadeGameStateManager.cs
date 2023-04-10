using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArcadeGameState {
    LOADING,
    IN_START_SCREEN,
    IN_SHOW_IN_ANIMATION,
    IN_TUTORIAL,
    IN_GAME,
    TERMINATED
}

public class ArcadeGameStateManager : MonoBehaviour
{
    public ArcadeGameState arcadeGameState = ArcadeGameState.LOADING;
}
