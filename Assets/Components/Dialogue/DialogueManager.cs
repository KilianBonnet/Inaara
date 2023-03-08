using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private GameObject dialogueContainer;
    private TextMeshProUGUI speakerName;
    private DialogueBoxAnimatior dialogueBox;
    private GameObject endIndicator;
    
    [SerializeField] private DialogueContainer[] dialogues;
    private int dialogueIterator;

    private void Start()
    {
        // Searching "Canvas"
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas not found! Please add a Canvas on your scene first.");
            Destroy(this); // Self-destroying script
        }

        // Searching "Dialogue Container"
        foreach (Transform child in canvas.transform)
        {
            if (child.gameObject.name != "Dialogue Container") continue;
            dialogueContainer = child.gameObject;
            break;
        }

        if (dialogueContainer == null)
        {
            Debug.LogError("Dialogue Container not found! Please add a Dialogue Container in your Canvas first.");
            Destroy(this); // Self-destroying script
        }

        // Searching "Speaker Name" & "Dialogue Box"
        foreach (Transform child in dialogueContainer.transform)
        {
            switch (child.gameObject.name)
            {
                case "Speaker Name":
                    speakerName = child.gameObject.GetComponent<TextMeshProUGUI>();
                    break;
                case "Dialogue Box":
                    dialogueBox = child.gameObject.GetComponent<DialogueBoxAnimatior>();
                    break;
                case "Dialogue End Indicator":
                    endIndicator = child.gameObject;
                    break;
            }
        }
        
        if (speakerName == null)
        {
            Debug.LogError("Speaker Name not found! Please add a TextMeshPro in your Dialogue Container first.");
            Destroy(this); // Self-destroying script
        }
        
        if (dialogueBox == null)
        {
            Debug.LogError("Dialogue Box not found! Please add a Dialogue Box in your Dialogue Container first.");
            Destroy(this); // Self-destroying script
        }
        
        if (endIndicator == null)
        {
            Debug.LogError("Dialogue End Indicator not found! Please add an Image in your Dialogue Container first.");
            Destroy(this); // Self-destroying script
        }
    }

    public void Play()
    {
        dialogueIterator = 0;
        dialogueContainer.SetActive(true);
        PlayOne(dialogueIterator);
    }

    private void PlayOne(int dialogueIndex)
    {
        endIndicator.SetActive(false);
        speakerName.text = dialogues[dialogueIndex].speakerName;
        dialogueBox.Display(dialogues[dialogueIndex].dialogue);
        
    }

    private void Update()
    {
        // If there is no animation, the dialogue line is terminated
        if (!dialogueBox.isOnAnimation)
            endIndicator.SetActive(true);
        
        // Check if the left mouse button is clicked
        if (!Input.GetMouseButtonDown(0))
            return;

        if (dialogueBox.isOnAnimation)
        {
            dialogueBox.FastEnd();
            return;
        }
        
        // If the dialogue is finished, close the dialogue window.
        if (dialogueIterator >= dialogues.Length - 1)
        {
            CloseDialogue();
            return;
        }
        
        dialogueIterator++;
        PlayOne(dialogueIterator);
    }

    private void CloseDialogue()
    {
        dialogueIterator = 0;
        speakerName.text = "";
        dialogueContainer.SetActive(false);
    }
}
