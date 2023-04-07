using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : Interactable
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        RenderSettings.fogColor = Color.black;
        while (RenderSettings.fogDensity < 0.6)
        {
            RenderSettings.fogDensity++;
        }
        IsTerminated = true;
    }
}
