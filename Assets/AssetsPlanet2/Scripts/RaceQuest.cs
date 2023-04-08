using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceQuest : Quest
{
    public override void BeginQuest()
    {
        questName = "Une course viruelle";
        questDescription = "Suivez les instruction de Unity Chan.";
        questManager.Add(this);
    }
}
