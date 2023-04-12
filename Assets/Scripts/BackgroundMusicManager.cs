using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] backgroundMusics;
    [SerializeField] private AudioClip[] ambiantSounds;
    AudioSource audioSource;

    private int countBGM;
    private int currentMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        countBGM = backgroundMusics.Length;

        currentMusic = 0;

        for (int i = 0; i < ambiantSounds.Length; i++)
        {
            AudioSource ambiantSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
            ambiantSource.loop = true;
            ambiantSource.clip = ambiantSounds[i];
            ambiantSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && countBGM > 0)
        {
            audioSource.clip = backgroundMusics[currentMusic];
            audioSource.volume = 0.05f;
            audioSource.Play();
            currentMusic = (currentMusic + 1) % countBGM;
        }
    }
}
