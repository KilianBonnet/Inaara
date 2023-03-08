using UnityEngine;

[System.Serializable]
public struct DialogueBox
{
    public string speakerName;
    [TextArea] public string dialogue;
}