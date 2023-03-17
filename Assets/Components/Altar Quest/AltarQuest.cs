using UnityEngine;

public class AltarQuest : Quest
{
    private Altar[] altars;
    private QuestManager questManager;

    private readonly string desctiptionRoot = "Inspecter les autels de la planète ";
        
    private void Start()
    {
        if ((questManager = FindObjectOfType<QuestManager>()) == null)
        {
            Debug.LogError("Cannot find QuestManager !");
            Destroy(this);
        }
        
        altars = FindObjectsOfType<Altar>();
    }

    public override void BeginQuest()
    {
        questName = "Voyage dans le brouillard";
        questDescription = "Inspecter les autels de la planète (0/" + altars.Length + ")";
        questManager.Add(this);
    }

    public void CheckAltar()
    {
        int nbActivatedAltar = 0;
        foreach (Altar altar in altars) if (altar.isActivated) nbActivatedAltar++;
        
        questDescription = desctiptionRoot + "(" + nbActivatedAltar + "/" + altars.Length + ")";
        questManager.Refresh(this);
    }
}
