using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    private TextMeshProUGUI interactionTextUI;
    private PlayerStateManager playerStateManager;
    
    private bool isDisplaying;

    private List<Interactable> interactions = new();

    private void Start()
    {
        // Find the Player State Manager
        if ((playerStateManager = FindObjectOfType<PlayerStateManager>()) == null)
        {
            Debug.LogError("Cannot find object of type PlayerStateManager!");
            Destroy(this); // Self-destroy
        }

        // Finding interactionTextUI
        foreach (Transform child in transform)
            if(child.gameObject.name == "Panel")
                foreach (Transform childOfPanel in child)
                    if (childOfPanel.gameObject.name == "Interaction Text")
                        interactionTextUI = childOfPanel.gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Add(Interactable interaction)
    {
        interactions.Insert(0, interaction);
        TryDisplaying();
    }

    public void Remove(Interactable interactable)
    {
        interactions.Remove(interactable);
        if (interactions.Count == 0) StopDisplaying();
        else TryDisplaying();
    }

    private void Update()
    {
        if (isDisplaying && (playerStateManager.PlayerState != PlayerState.PLAYING || interactions.Count == 0)) StopDisplaying();
        else if (isDisplaying && Input.GetKeyDown(KeyCode.E) && playerStateManager.PlayerState == PlayerState.PLAYING && interactions.Count > 0) interactions[0].OnInteract();
        else if (!isDisplaying && playerStateManager.PlayerState == PlayerState.PLAYING && interactions.Count > 0) TryDisplaying();
    }


    private void StopDisplaying()
    {
        isDisplaying = false;
        foreach (Transform child in transform) child.gameObject.SetActive(false);
    }

    private void TryDisplaying()
    {
        if(interactions.Count == 0) return;
        
        isDisplaying = true;
        foreach (Transform child in transform) child.gameObject.SetActive(true);
        interactionTextUI.text = interactions[0].interactionText;
    }
}
