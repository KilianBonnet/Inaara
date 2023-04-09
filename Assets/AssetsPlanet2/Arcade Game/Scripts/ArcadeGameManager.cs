using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGameManager : MonoBehaviour
{
    private GameObject inaara;
    private AudioSource startAudio;

    private bool isGameStarted;

    void Start()
    {
        // Initializing parameters
        inaara = GameObject.Find("Inaara");
        inaara.SetActive(false);
        startAudio = GetComponent<AudioSource>();
    }

    private void Update() {
        StartDelayed();
    }

    private void StartDelayed() {
        if(isGameStarted) return;           // The game is already stared, nothing to do here
        if(startAudio.isPlaying) return;    // The starting audio hasn't finished yet, nothing to do here

        // Starting the game
        isGameStarted = true;
        GameObject.Find("Arcade BGM").GetComponent<AudioSource>().Play();
        GameObject.Find("Camera Render").GetComponent<Camera>().enabled = true;
    }
}
