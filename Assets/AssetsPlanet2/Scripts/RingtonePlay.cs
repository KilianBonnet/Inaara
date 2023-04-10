using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingtonePlay : Interactable
{
    [SerializeField] private List<AudioSource> bgms;
    private AudioSource audio;
    
    private float timer;
    private bool isStarted;

    void Start()
    {
        ShouldBeDestroyed = true;
        audio = GetComponent<AudioSource>();
    }


    public override void Interact()
    {
        foreach (var bgm in bgms) bgm.Pause();

        isStarted = true;
        audio.Play();
    }

    private void Update() {
        if(!isStarted || audio.isPlaying) return;
        foreach (var bgm in bgms) bgm.UnPause();
        IsTerminated = true;
        isStarted = false;
    }
}
