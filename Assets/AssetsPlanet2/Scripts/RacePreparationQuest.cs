using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePreparationQuest : Quest
{
    public override void BeginQuest()
    {
        questName = "Une sensation de vitesse";
        questDescription = "Trouvez l'organisatrice";
        questManager.Add(this);
    }
}
