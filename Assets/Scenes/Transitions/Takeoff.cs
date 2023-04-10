using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Takeoff : Interactable
{
    private bool fade = false;
    private AudioSource _audioSource;
    public String nextSceneName;
    private Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if((image = GameObject.Find("Fade").GetComponent<Image>()) == null) {
            Debug.LogError("Fade not found !");
            return;
        }
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
        fade = true;
        if(_audioSource != null)
            _audioSource.Play();
    }
}
