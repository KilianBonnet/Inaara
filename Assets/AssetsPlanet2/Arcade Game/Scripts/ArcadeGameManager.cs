using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArcadeGameManager : MonoBehaviour
{
    // Global Parameters
    private GameObject inaara;
    private AudioSource gameAudio;
    private ArcadeGameStateManager arcadeGameStateManager;

    // Game Parameters
    [SerializeField] AudioClip newHintAudio;
    [SerializeField] GameObject[] trashes;
    [SerializeField] Transform trashSpawnPoint;
    private TextMeshProUGUI scoreUi;
    private TextMeshProUGUI hintText;
    private Image hintPanel;
    private int score;
    private float lastTrashTime;
    private bool tenThousandReached;
    private bool twentyThousandReached;

    void Start()
    {
        // Finding Components
        arcadeGameStateManager = FindObjectOfType<ArcadeGameStateManager>();
        gameAudio = GetComponent<AudioSource>();
        inaara = GameObject.Find("Inaara");
        scoreUi = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        hintText = GameObject.Find("Hint Text").GetComponent<TextMeshProUGUI>();
        hintPanel = GameObject.Find("Arcade Hint Panel").GetComponent<Image>();

        // Initializing parameters
        inaara.SetActive(false);
    }

    private void Update() {
        TryLoadGame();
        UpdateScore();
        ProcessGame();
        CheckScore();
    }

    private void TryLoadGame() {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.LOADING) return; // The game is already stared, nothing to do here
        if(gameAudio.isPlaying) return;                                              // The starting audio hasn't finished yet, nothing to do here

        // Starting the game
        arcadeGameStateManager.arcadeGameState = ArcadeGameState.IN_START_SCREEN;
        GameObject.Find("Arcade BGM").GetComponent<AudioSource>().Play();
        GameObject.Find("Camera Render").GetComponent<Camera>().enabled = true;

        GameObject dialogueContainer;                                                 // Turning off potential unclosed dialog
        if((dialogueContainer = GameObject.Find("Dialogue Container")) != null ) dialogueContainer.SetActive(false);
        Destroy(GameObject.Find("ArcadeMachineV1").GetComponent<DialogueManager>());
    }

    public void StartGame() {
        arcadeGameStateManager.arcadeGameState = ArcadeGameState.IN_SHOW_IN_ANIMATION;

        GameObject.Find("Start Panel").SetActive(false);                    // Turn off the "Press Enter To Play" menu
        GameObject.Find("Start Audio").GetComponent<AudioSource>().Play();  // Play the start sound audio
        scoreUi.enabled = true;

        foreach (Transform child in GameObject.Find("Inaara Car").transform) 
            child.gameObject.SetActive(true);                               // Enable all children of the car (Including the mesh of tge car)
    }

    public void OnHit(GameObject car) {
        TutorialOnHit(car);
        GameOnHit(car);
    }

    public void TutorialLeftRightStage() {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_SHOW_IN_ANIMATION) return;
        arcadeGameStateManager.arcadeGameState = ArcadeGameState.IN_TUTORIAL;
        gameAudio.clip = newHintAudio;
        gameAudio.volume = 1f;
        ShowHint("Déplace toi de gauche à droite !");
        FindObjectOfType<TutorialLeftRight>().enabled = true;
    }

    public void TutorialAvoid() {
        hintText.text = "Esquive les obstcles ! Ils te font reculer ...";
        gameAudio.Play();
        Invoke("GenerateTutorialTrash", 2f);
    }

    private void GenerateTutorialTrash() {
        HideHintUi();
        Invoke("GameStart", 3);
        Instantiate(trashes[0], trashSpawnPoint.position, trashSpawnPoint.rotation);
    }

    private void GenerateTrash() {
        Vector3 spawnPosition = trashSpawnPoint.localPosition;
        spawnPosition.z += Random.Range(0, 16) - 8;
        Instantiate(trashes[Random.Range(0, trashes.Length)], spawnPosition, trashSpawnPoint.rotation);
    }

    private void TutorialOnHit(GameObject car) {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_TUTORIAL) return;
        car.GetComponent<AudioSource>().Play();
        ShowHint("Ce n'est pas grave, esquiver n'est pas facile. Essaye encore !");
        CancelInvoke();
        Invoke("GenerateTutorialTrash", 2f);
    }

    private void GameOnHit(GameObject car)
    {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_GAME) return;
        car.GetComponent<AudioSource>().Play();
        car.transform.Translate(Vector3.left * 2);
    }
    
    private void GameStart() {
        ShowHint("Voilà un adversaire pour rendre le jeu plus interessant !");
        foreach (Transform child in GameObject.Find("Opponents").transform) child.gameObject.SetActive(true);
        Invoke("TurnGameStatusOn", 3);
    }

    private void ShowHint(string hint) {
        hintText.enabled = true;
        hintPanel.enabled = true;
        hintText.text = hint;
        gameAudio.Play();
    }

    private void HideHintUi() {
        hintPanel.enabled = false;
        hintText.enabled = false;
    }

    private void UpdateScore() {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_GAME) return;
        score += (int) (Time.deltaTime * 1000);
        scoreUi.text = "Score : " + score.ToString("N0");
    }
    
    private void ProcessGame() {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_GAME) return;
        lastTrashTime += Time.deltaTime;

        bool shouldInstantiate = false;
        shouldInstantiate = score > 20_000 && lastTrashTime > 1f;
        shouldInstantiate = shouldInstantiate || (score > 10_000 && lastTrashTime > 1.5f);
        shouldInstantiate = shouldInstantiate || lastTrashTime > 2f;

        if(!shouldInstantiate) return;
        GenerateTrash();
        lastTrashTime = 0;
    }

    private void TurnGameStatusOn(){
        arcadeGameStateManager.arcadeGameState = ArcadeGameState.IN_GAME;
        HideHintUi();
    }

    private void CheckScore()
    {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_GAME) return;
        if(!tenThousandReached && score >= 10_000) {
            tenThousandReached = true;
            CongratsScore(10_000);
        }

        if(!twentyThousandReached && score >= 20_000) {
            twentyThousandReached = true;
            CongratsScore(20_000);
        }
    }

    private void CongratsScore(int milestone) {
        ShowHint($"{milestone} points, bravo ! La partie s'accelère !!");
        Invoke("HideHintUi", 5);
    }   

    public void OnLoseTriggered(Transform car) {
        if(arcadeGameStateManager.arcadeGameState != ArcadeGameState.IN_GAME) return;

        if(car.name == "Inaara Car") {
            ShowHint("Ne restons pas sur une défaite, recommençons");
            arcadeGameStateManager.arcadeGameState = ArcadeGameState.IN_SHOW_IN_ANIMATION;
            Invoke("ResetGame", 3);
        }

        if(car.name == "Opponent Car") {
            arcadeGameStateManager.arcadeGameState = ArcadeGameState.TERMINATED;
            GameObject.Find("Arcade BGM").GetComponent<AudioSource>().Pause();
            FindObjectOfType<RaceQuest>().FinishRace();
            inaara.SetActive(true);
            Destroy(GetComponent<AudioListener>());
        }
    }

    private void ResetGame() {
        HideHintUi();
        arcadeGameStateManager.arcadeGameState = ArcadeGameState.IN_GAME;
        score = 0;
        lastTrashTime = 0;
        tenThousandReached = false;
        twentyThousandReached = false;

        GameObject.Find("Inaara Car").AddComponent<CarShowIn>();
        foreach (Transform child in GameObject.Find("Opponents").transform) 
            child.gameObject.AddComponent<OpponentShowIn>();
    }
}
