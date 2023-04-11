using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private PlayerStateManager playerStateManager;
    private PlayerState previousState;
    private GameObject menu;
    private List<AudioSource> pausedAudioSources = new List<AudioSource>();
    [SerializeField] private GameObject planetMenu;
    [SerializeField] private TextMeshProUGUI menuToggleText;

    private void Start() {
        playerStateManager = FindObjectOfType<PlayerStateManager>();
    }

    private void Update() {
        if(!Input.GetKeyDown(KeyCode.Escape)) return;

        if(playerStateManager.PlayerState == PlayerState.IN_MENU) CloseUi();
        else OpenUi();
    }

    public void CloseUi() {
        playerStateManager.UpdateState(previousState);
        foreach (Transform child in transform) child.gameObject.SetActive(false);
        ResumePausedAudioSources();
        Time.timeScale = 1;
    }

    public void OpenUi() {
        previousState = playerStateManager.PlayerState;
        playerStateManager.UpdateState(PlayerState.IN_MENU);
        PauseActiveAudioSources();
        Time.timeScale = 0;
        foreach (Transform child in transform) child.gameObject.SetActive(true);
    }

    public void ResumePausedAudioSources() {
        foreach(AudioSource audioSource in pausedAudioSources) audioSource.UnPause();
        pausedAudioSources.Clear();
    }

    public void PauseActiveAudioSources() {
        foreach(AudioSource audioSource in FindObjectsOfType<AudioSource>())
            if(audioSource.isPlaying) {
                pausedAudioSources.Add(audioSource);
                audioSource.Pause();
            }
    }

    public void LoadScene(string sceneName) {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void TogglePlanetMenu() {
        if(menuToggleText.text == "> Dev backdoor") {
            planetMenu.SetActive(true);
            menuToggleText.text = "-";
        }  
        else {
            planetMenu.SetActive(false);
            menuToggleText.text = "> Dev backdoor";
        }
    }
}
