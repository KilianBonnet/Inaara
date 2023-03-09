using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private bool isStarted = false;
    private GameObject dialogueContainer;
    private TextMeshProUGUI speakerName;
    private DialogueBoxAnimatior dialogueBox;
    private GameObject endIndicator;
    private AudioSource skipAudio;
    
    [SerializeField] private DialogueContainer[] dialogues;
    private int dialogueIterator;

    private void Start()
    {
        // Searching "Canvas"
        GameObject canvas = GameObject.Find("Dialogue Manager");
        if (canvas == null)
        {
            Debug.LogError("Dialogue Manager prefab not found! Please add a the Dialogue Manager prefab on your scene first.");
            Destroy(this); // Self-destroying script
        }

        // Searching "Dialogue Container"
        foreach (Transform child in canvas.transform)
        {
            switch (child.gameObject.name)
            {
                case "Dialogue Container":
                    dialogueContainer = child.gameObject;
                    break;
                case "Skip Audio":
                    skipAudio = child.gameObject.GetComponent<AudioSource>();
                    break;
            }
        }

        if (dialogueContainer == null)
        {
            Debug.LogError("Dialogue Container not found! Please add a Dialogue Container in your Dialogue Manager first.");
            Destroy(this); // Self-destroying script
        }
        
        if (skipAudio == null)
        {
            Debug.LogError("Skip Audio not found! Please add an AudioSource Dialogue Manager first.");
            Destroy(this); // Self-destroying script
        }

        // Searching for expected child components
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
        isStarted = true;
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
        // Check if the dialogue is started
        if(!isStarted)
            return;
        
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
        
        // Play the audio for dialogue transition
        skipAudio.Play();
        
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
        isStarted = false;
        dialogueContainer.SetActive(false);
    }
}
