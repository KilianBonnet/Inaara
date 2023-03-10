using UnityEngine;

public enum PlayerState
{
    PLAYING,
    IN_DIALOGUE,
}

public class PlayerStateManager : MonoBehaviour
{
    public PlayerState PlayerState { get; private set; } = PlayerState.PLAYING;
    
    public void UpdateState(PlayerState state)
    {
        PlayerState = state;
    }
}
