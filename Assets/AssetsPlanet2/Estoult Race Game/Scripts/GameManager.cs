using System.Collections; using UnityEngine;
public class GameManager : MonoBehaviour
{
    public PlayerControls playerControls;
    public AIControls[] aiControls;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;

    public AudioSource audioSource;
    public AudioClip  lowBeep;
    public AudioClip  highBeep;

    public GameObject camera;
    
    void Awake()
    {
        StartGame();
    }
    public void StartGame()
    {
        camera.GetComponent<Animator>().SetBool("isAnimating", true);
        FreezePlayers(true);
        StartCoroutine("WaitCameraAndStart");
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("3");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(1);
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(2);
        yield return new WaitForSeconds(1);
        Debug.Log("1");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(3);
        yield return new WaitForSeconds(1);
        Debug.Log("GO");
        audioSource.PlayOneShot(highBeep);
        tricolorLights.SetProgress(4);
        StartRacing();
        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
    }

    IEnumerator WaitCameraAndStart()
    {
        yield return new WaitForSeconds(6f);
        camera.GetComponent<Animator>().SetBool("isAnimating", false);
        StartCoroutine("Countdown");
    }


    public void StartRacing()
    {
        FreezePlayers(false);
    }
    void FreezePlayers(bool freeze)
    {
        foreach (AIControls controls in aiControls)
            controls.enabled = !freeze;
        playerControls.enabled = !freeze;
    }
}