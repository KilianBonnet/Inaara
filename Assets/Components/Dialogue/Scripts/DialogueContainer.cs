using UnityEngine;

[System.Serializable]
public struct DialogueContainer
{
    public string speakerName;
    public float audioPitch;
    public Interactable script;
    [TextArea] public string dialogue;
}