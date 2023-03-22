using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinQuest : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        questName = "a";
        questDescription = "b";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void BeginQuest()
    {
        Debug.Log("quest started !");
    }
}
