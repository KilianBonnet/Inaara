using TMPro;
using UnityEngine;

public class DialogueBoxAnimatior : MonoBehaviour
{
    public bool isOnAnimation;
    
    private float characterPerSecond = 25;
    private float characterFrequency;
        
    private float timeBuffer;
    private TextMeshProUGUI dialogueBox;
    private string textToDisplay;
    
    private AudioSource typingAudio;
    private float pitch;

    // Start is called before the first frame update
    private void Start()
    {
        dialogueBox = GetComponent<TextMeshProUGUI>();

        if (dialogueBox == null)
        {
            Debug.LogError("TextMeshPro not found! Please add a TextMeshPro on your Gameobject first.");
            Destroy(this);
        }
        dialogueBox.text = "";
        characterFrequency = 1 / characterPerSecond ;

        foreach (Transform child in transform)
            if (child.gameObject.name == "Typing Audio")
                typingAudio = child.gameObject.GetComponent<AudioSource>();
        
        if (typingAudio == null)
        {
            Debug.LogError("Typing Audio not found! Please add an AudioSource in Dialogue Manager first.");
            Destroy(this); // Self-destroying script
        }
    }
    
    public void Display(string dialogueContent, float pitch)
    {
        textToDisplay = dialogueContent;
        isOnAnimation = true;
        timeBuffer = 0;
        if (dialogueBox != null) dialogueBox.text = "";
        this.pitch = pitch;
    }
    
    // Update is called once per frame
    private void Update()
    {
        // Check if a text need to be displayed
        if(!isOnAnimation) return;
        
        // Check if the next character need to be displayed
        if (timeBuffer < characterFrequency)
        {
            timeBuffer += Time.deltaTime;
            return;
        }
        
        if (textToDisplay.Length == 0)
        {
            isOnAnimation = false;
            return;
        }

        dialogueBox.text += textToDisplay[0];
        timeBuffer = 0;
        textToDisplay = textToDisplay.Substring(1);
        
        typingAudio.pitch = pitch;
        typingAudio.Play();
    }

    public void FastEnd()
    {
        dialogueBox.text += textToDisplay;
        isOnAnimation = false;
        textToDisplay = "";
        timeBuffer = 0;
    }
}
