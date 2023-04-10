using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePreparationQuest : Quest
{
    public override void BeginQuest()
    {
        questName = "Une sensation de vitesse";
        questDescription = "Trouvez l'organisatrice.";
        questManager.Add(this);
    }

    public void UpdateUpdateQUest(string title, string questDescription) {
        questName = title;
        this.questDescription = questDescription;

        questManager.Remove(this);
        questManager.Add(this);
    }

    public void EndQUest() {
        questManager.Remove(this);
    }
}
