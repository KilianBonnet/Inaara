using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : Interactable
{
    [SerializeField] private Transform statueHeadAnchor;
    [SerializeField] private ParticleSystem headAnchorParticle;
    [SerializeField] private AudioClip oldMemoriesAudio;
    private AudioSource bgm;
    private Transform soulTransform;

    private void Start() {
        bgm =  GameObject.Find("BGM").GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        FindObjectOfType<FollowSoulQuest>().UpdateQuest(
            "Le récit de l’au-delà",
            "Rapprochez-vous de la tombe du dernier porteur de la légende."
        );
    }

    public void Play(Transform soulTransform) {
        this.soulTransform = soulTransform;
        soulTransform.position = statueHeadAnchor.position;
        soulTransform.rotation = statueHeadAnchor.rotation;
        soulTransform.localScale /= 2;
        GetComponent<AudioSource>().Play();
        headAnchorParticle.Play();
        RenderSettings.fogDensity = .02f;
        bgm.Pause();
        bgm.volume = .07f;
        Invoke("StartBGMDelayed", 5);
        Invoke("StartDialog", 5);
    }

    private void StartBGMDelayed(){
        bgm.clip = oldMemoriesAudio;
        bgm.pitch = 1f;
        bgm.Play();
    }

    private void StartDialog() {
        GetComponent<DialogueManager>().Interact();
    }
}
