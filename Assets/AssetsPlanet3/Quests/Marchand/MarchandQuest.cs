using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchandQuest : Quest
{

    private QuestManager questManager;

    // Start is called before the first frame update
    void Start()
    {
        if ((questManager = FindObjectOfType<QuestManager>()) == null)
        {
            Debug.LogError("Cannot find QuestManager !");
            Destroy(this);
        }

        BeginQuest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void BeginQuest()
    {
        questManager.Add(this);
    }

    public void ChangeObjective(string description)
    {
        questDescription = description;
        questManager.Refresh(this);
    }
}
