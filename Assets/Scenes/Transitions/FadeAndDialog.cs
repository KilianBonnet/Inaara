using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAndDialog : MonoBehaviour
{
 
    private Image image;
    private bool fade = true;
    
    void Awake()
    {
        StartCoroutine(StartDialogue());
    }
    
    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("Fade").GetComponent<Image>();
        image.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (image.color.a > 0f && fade)
        {
            var tempColor = image.color;
            tempColor.a -= 0.0005f;
            image.color = tempColor;
        }
        else
        {
            fade = false;
        }
    }
    
    private IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(3);
        GetComponent<DialogueManager>().Interact();
    }
}
