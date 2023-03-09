using TMPro;
using UnityEngine;

public class DialogueBoxAnimatior : MonoBehaviour
{
    public bool isOnAnimation;
    
    [SerializeField] private float characterPerSecond = 20;
    private float characterFrequency;
        
    private float timeBuffer;
    private TextMeshProUGUI dialogueBox;
    private string textToDisplay;
    
    
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
    }
    
    public void Display(string dialogueContent)
    {
        textToDisplay = dialogueContent;
        isOnAnimation = true;
        timeBuffer = 0;

        if (dialogueBox != null) dialogueBox.text = "";
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
    }

    public void FastEnd()
    {
        dialogueBox.text += textToDisplay;
        isOnAnimation = false;
        textToDisplay = "";
        timeBuffer = 0;
    }
}
