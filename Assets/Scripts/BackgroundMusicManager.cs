using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] backgroundMusics;
    AudioSource audioSource;

    private int countBGM;
    private int currentMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        countBGM = backgroundMusics.Length;

        currentMusic = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && countBGM > 0)
        {
            audioSource.clip = backgroundMusics[currentMusic];
            audioSource.volume = 0.5F;
            audioSource.Play();
            currentMusic = (currentMusic + 1) % countBGM;
        }
    }
}
