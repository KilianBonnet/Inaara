using UnityEngine;

public class AltarQuest : Quest
{
    [SerializeField] private GameObject npc;
    
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


        if (nbActivatedAltar >= altars.Length)
        {
            EndQuest();
            return;
        }
        
        
        questDescription = desctiptionRoot + "(" + nbActivatedAltar + "/" + altars.Length + ")";
        questManager.Refresh(this);
    }

    private void EndQuest()
    {
        questManager.Remove(this);
        
        questName = "Voyage dans le brouillard";
        questDescription = "Faites votre rapport à la présence à l'entrée du bois.";

        DialogueManager loopDialogue = npc.GetComponent<DialogueManager>();
        loopDialogue.ShouldBeDestroyed = true;
        loopDialogue.IsTerminated = true;
        
        questManager.Add(this);
    }
}
