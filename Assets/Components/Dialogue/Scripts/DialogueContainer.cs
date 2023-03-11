using UnityEngine;

[System.Serializable]
public struct DialogueContainer
{
    public string speakerName;
    public float audioPitch;
    [TextArea] public string dialogue;
}