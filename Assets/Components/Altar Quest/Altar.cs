using UnityEngine;

public class Altar : Interactable
{
    public bool isActivated;
    private AltarQuest quest;

    private Renderer gemRenderer;
    private Light altarLight;

    private void Start()
    {
        if ((quest = FindObjectOfType<AltarQuest>()) == null)
        {
            Debug.LogError("Cannot find AltarQuest !");
            Destroy(this);
        }
        
        

        foreach (Transform child in transform)
        {
            switch (child.gameObject.name)
            {
                case "Gem":
                    gemRenderer = child.gameObject.GetComponent<Renderer>();
                    break;
                case "Point Light":
                    altarLight = child.gameObject.GetComponent<Light>();
                    break;
            }
        }
        
        IsTerminated = true;
    }

    public override void Interact()
    {
        ChangeAltarRender();
        isActivated = true;
        quest.CheckAltar();
    }

    private void ChangeAltarRender()
    {
        gemRenderer.material.SetColor("_EmissionColor", new Color(0, 241, 233));
        Color c = altarLight.color;
        c.r = 0;
        c.g = .9f;
        c.b = 1;
        altarLight.color = c;
        altarLight.intensity = 1.5f;
    }
}
