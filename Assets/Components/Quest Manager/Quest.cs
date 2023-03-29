using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    public string questName;
    public string questDescription;
    public abstract void BeginQuest();
    
    protected QuestManager questManager;
    private void Start()
    {
        if ((questManager = FindObjectOfType<QuestManager>()) == null)
        {
            Debug.LogError("Cannot find QuestManager !");
            Destroy(this);
        }
    }
}
