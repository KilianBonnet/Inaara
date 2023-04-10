using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Takeoff_vanilla : Interactable
{
    private bool fade = false;
    private AudioSource _audioSource;
    public String nextSceneName;
    private Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
                if (!_audioSource.isPlaying)
                {
                    fade = false;
                    IsTerminated = true;
                    SceneManager.LoadScene(nextSceneName);
                }
            }
        }
    }

    public override void Interact()
    {
        //IsTerminated = true;
        fade = true;
        _audioSource.Play();
    }
}
