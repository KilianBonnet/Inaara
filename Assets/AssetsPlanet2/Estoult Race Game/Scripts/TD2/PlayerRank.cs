using System;

[Serializable]
public class PlayerRank
{
    public CarIdentity identity;
    public int lapNumber = 1;
    public int lastCheckpoint = 0;
    public bool hasFinished = false;
    public int rank = -1;

    public PlayerRank(CarIdentity carIdentity)
    {
        identity = carIdentity;
    }
}
