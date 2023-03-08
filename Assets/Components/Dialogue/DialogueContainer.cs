using UnityEngine;

[System.Serializable]
public struct DialogueContainer
{
    public string speakerName;
    [TextArea] public string dialogue;
}