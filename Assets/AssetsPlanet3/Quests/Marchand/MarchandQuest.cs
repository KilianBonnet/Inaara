using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchandQuest : Quest
{

    void Awake()
    {
        StartCoroutine(StartQuest());
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

    private IEnumerator StartQuest()
    {
        yield return new WaitForSeconds(1);
        BeginQuest();
    }
}
