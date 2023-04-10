using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class illuminati : Interactable
{
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        _audioSource.Play();
        IsTerminated = true;
    }
}
