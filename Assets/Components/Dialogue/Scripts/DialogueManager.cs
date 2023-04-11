using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : Interactable
{
    // Global elements
    private PlayerStateManager playerStateManager;

    // UI elements
    private GameObject dialogueContainer;
    private TextMeshProUGUI speakerNameUI;
    private DialogueBoxAnimatior dialogueBox;
    private GameObject endIndicator;

    // Audio elements
    private AudioSource skipAudio;
    
    // Zoom dialogue component
    public ZoomInOut zoomInOut = null;


    // Parameters
    [SerializeField] private DialogueContainer[] dialogues;
    
    // Internal variables
    private int dialogueIterator;
    private bool isStarted;
    private bool hasZoomInOut = true;

    private void Start()
    {
        // Find the Player State Manager
        if ((playerStateManager = FindObjectOfType<PlayerStateManager>()) == null)
        {
            Debug.LogError("Cannot find object of type PlayerStateManager!");
            Destroy(this); // Self-destroy
        }
        // Find the Player State Manager
        if (zoomInOut == null)
        {
            Debug.LogError("Cannot find object of type ZoomInOut!");
            hasZoomInOut = false;
        }
        
        
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
            Debug.LogError("Skip Audio not found! Please add an AudioSource in Dialogue Manager first.");
            Destroy(this); // Self-destroying script
        }

        // Searching for expected child components
        foreach (Transform child in dialogueContainer.transform)
        {
            switch (child.gameObject.name)
            {
                case "Speaker Name":
                    speakerNameUI = child.gameObject.GetComponent<TextMeshProUGUI>();
                    break;
                case "Dialogue Box":
                    dialogueBox = child.gameObject.GetComponent<DialogueBoxAnimatior>();
                    break;
                case "Dialogue End Indicator":
                    endIndicator = child.gameObject;
                    break;
            }
        }
        
        if (speakerNameUI == null)
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

    public override void Interact()
    {
        playerStateManager.UpdateState(PlayerState.IN_DIALOGUE);
        dialogueIterator = 0;
        dialogueContainer.SetActive(true);
        isStarted = true;
        
        if(hasZoomInOut) zoomInOut.ZoomIn();
        

        
        PlayOne(dialogueIterator);
    }

    /**
     * Play one iteration of the dialogue
     */
    private void PlayOne(int dialogueIndex)
    {
        // Updating UI elements
        endIndicator.SetActive(false);
        speakerNameUI.text = dialogues[dialogueIndex].speakerName;
        dialogueBox.Display(dialogues[dialogueIndex].dialogue, dialogues[dialogueIndex].audioPitch);
        
        // Checking for script to start
        if(dialogues[dialogueIndex].script != null) dialogues[dialogueIndex].script.Interact();
    }

    private void Update()
    {
        // Check if the dialogue is started
        if(!isStarted) return;
        
        // Check if an animation is running (no FastEnd possible)
        if(!IsScriptTerminated()) return;

        // If there is no animation, the dialogue line is terminated : Display the end line
        if (!dialogueBox.isOnAnimation) endIndicator.SetActive(true);

        // Check if the left mouse button is clicked or the return key
        if (!(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))) return;

        if (dialogueBox.isOnAnimation && IsScriptTerminated())
        {
            dialogueBox.FastEnd();
            return;
        }
        
        skipAudio.Play(); // Play the audio for dialogue transition
        TerminateScript(); // Terminate the current script
            
        // If the dialogue is finished, close the dialogue window.
        if (dialogueIterator >= dialogues.Length - 1)
        {
            CloseDialogue();
            return;
        }
        
        // Play the next iteration of the dialogue
        dialogueIterator++;
        PlayOne(dialogueIterator);
    }

    /**
     * Method called when the player close the dialogue
     */
    private void CloseDialogue()
    {
        playerStateManager.UpdateState(PlayerState.PLAYING);
        speakerNameUI.text = "";
        dialogueContainer.SetActive(false);
        IsTerminated = true;
        dialogueIterator = 0;
        isStarted = false;

        if(hasZoomInOut) zoomInOut.ZoomOut();
    }

    private bool IsScriptTerminated()
    {
        return dialogues[dialogueIterator].script == null || dialogues[dialogueIterator].script.IsTerminated;
    }
    
    private void TerminateScript()
    {
        if(dialogues[dialogueIterator].script == null) return; // Nothing to terminate
        if(dialogues[dialogueIterator].script.ShouldBeDestroyed) Destroy(dialogues[dialogueIterator].script);
    }
}
