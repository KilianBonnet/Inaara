using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCFix : Interactable
{
    [SerializeField] private ParticleSystem[] fireList;
    [SerializeField] AudioSource cleaningNoise;
    [SerializeField] GameObject[] toDisable;
    [SerializeField] GameObject[] toEnable;
    private bool isInteracted;

    public override void Interact()
    {
        foreach (GameObject g in toDisable) g.SetActive(false);
        foreach (GameObject g in toEnable) g.SetActive(true);
        foreach (ParticleSystem p in fireList) p.Stop();
        cleaningNoise.Play();
        isInteracted = true;
    }

    private void Update() {
        if(IsTerminated) return;
        IsTerminated = !cleaningNoise.isPlaying && isInteracted;
    }
}
