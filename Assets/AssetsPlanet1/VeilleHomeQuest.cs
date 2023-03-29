using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeilleHomeQuest : Quest
{
    private QuestManager questManager;
    
    // Start is called before the first frame update
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void BeginQuest()
    {
        Debug.Log("quest started !");
        questManager.Add(this);

        //questDescription = "1/1";
        //questManager.Refresh(this);
    }
}
