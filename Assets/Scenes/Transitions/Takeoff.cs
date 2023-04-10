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
    private MarchandQuest marchandQuest;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        image = GameObject.Find("Fade").GetComponent<Image>();
        marchandQuest = FindObjectOfType<MarchandQuest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            if (image.color.a < 1f)
            {
                var tempColor = image.color;
                tempColor.a += 0.001f;
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
        marchandQuest.ChangeObjective("");
        marchandQuest.ChangeName("");
        fade = true;
        _audioSource.Play();
    }
}
