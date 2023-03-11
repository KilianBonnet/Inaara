using TMPro;
using UnityEngine;

enum IntrodutionStatus
{
    FADE_IN,
    IDLE,
    FADE_OUT
}

public class PlanetIntroduction : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 3;

    private IntrodutionStatus status;
    private float timer;

    private TextMeshProUGUI planetNameUI;
    private TextMeshProUGUI planetDetailUI;
    private AudioSource audioSource;
    
    

    // Start is called before the first frame update
    void Start()
    {
        status = IntrodutionStatus.FADE_IN;
        timer = 0;

        foreach (Transform child in transform)
        {
            switch (child.gameObject.name)
            {
                case "Planet Name":
                    planetNameUI = child.gameObject.GetComponent<TextMeshProUGUI>();
                    break;
                case "Planet Detail":
                    planetDetailUI = child.gameObject.GetComponent<TextMeshProUGUI>();
                    break;
                    case "Fading Audio":
                    audioSource = child.gameObject.GetComponent<AudioSource>();
                    break;
            }
        }
        
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on child!");
            Destroy(this);
        }
        
        if (planetDetailUI == null || planetNameUI == null)
        {
            Debug.LogError("No TextMeshProUGUI found on child!");
            Destroy(this);
        }
        
        UpdatingAlpha(0);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < fadeDuration)
        {
            if (status == IntrodutionStatus.FADE_IN) UpdatingAlpha(timer/fadeDuration);
            if (status == IntrodutionStatus.FADE_OUT) UpdatingAlpha(1 - timer/fadeDuration);
            timer += Time.deltaTime;
        }

        if (timer > fadeDuration)
        {
            if (status == IntrodutionStatus.FADE_OUT) Destroy(gameObject);
            if (status == IntrodutionStatus.FADE_IN) status = IntrodutionStatus.IDLE;
            if (status == IntrodutionStatus.IDLE) status = IntrodutionStatus.FADE_OUT;
            timer = 0;
        }
    }



    private void UpdatingAlpha(float alpha)
    {
        Color c = planetNameUI.color;
        c.a = alpha;
        planetNameUI.color = c;
        
        c = planetDetailUI.color;
        c.a = alpha;
        planetDetailUI.color = c;
    }
}
