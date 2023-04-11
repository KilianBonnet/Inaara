using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoNext : Interactable
{
    private bool fade = false;
    public String nextSceneName;
    private Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("Fade").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            if (image.color.a < 1f)
            {
                var tempColor = image.color;
                tempColor.a += 0.005f;
                image.color = tempColor;
            }
            else
            {
                fade = false;
                IsTerminated = true;
                SceneManager.LoadScene(nextSceneName);

            }
        }
    }

    public override void Interact()
    {
        StartCoroutine(StartFade());
    }
    
    private IEnumerator StartFade()
    {
        yield return new WaitForSeconds(3);
        fade = true;
    }
}
