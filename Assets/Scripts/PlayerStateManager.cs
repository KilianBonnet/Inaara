using UnityEngine;

public enum PlayerState
{
    PLAYING,
    IN_DIALOGUE,
    IN_CINEMATIC
}

public class PlayerStateManager : MonoBehaviour
{
    public PlayerState PlayerState = PlayerState.PLAYING;
    
    public void UpdateState(PlayerState state)
    {
        PlayerState = state;
    }
}
