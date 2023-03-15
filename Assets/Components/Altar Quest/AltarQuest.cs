using UnityEngine;

public class AltarQuest : Quest
{
    private Altar[] altars;
    private QuestManager questManager;
        
    private void Start()
    {
        if ((questManager = FindObjectOfType<QuestManager>()) == null)
        {
            Debug.LogError("Cannot find QuestManager !");
            Destroy(this);
        }
        
        altars = FindObjectsOfType<Altar>();

        BeginQuest();
    }

    public override void BeginQuest()
    {
        questName = "Voyage dans le brouillard";
        questDescription = "Inspecter les autels de la planète (0/" + altars.Length + ")";
        questManager.Add(this);
    }
}
