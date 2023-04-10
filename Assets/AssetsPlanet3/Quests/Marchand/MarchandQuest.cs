using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchandQuest : Quest
{

    private GameObject merchandNpc;
    private GameObject oasisNpc;
    private GameObject pyramidNpc;
    private GameObject obeliskNpc;
    private GameObject spaceship;
    
    private int coconutsFound = 0;

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
        
        merchandNpc = GameObject.Find("MerchandNPCA");
        oasisNpc = GameObject.Find("OasisNPCA");
        pyramidNpc = GameObject.Find("PyramidNPCA");
        obeliskNpc = GameObject.Find("ObeliskNPCA");
        spaceship = GameObject.Find("Spaceship");
    }

    public void ChangeObjective(string description)
    {
        questDescription = description;
        questManager.Refresh(this);
    }
    
    public void ChangeName(string name)
    {
        questName = name;
        questManager.Refresh(this);
    }

    public void ActiveMerchandNPC()
    {
        merchandNpc.GetComponent<Interactor>().enabled = true;
        ActiveZoomCamera("ZoomGenerator");
        ActiveZoomCamera("TopOfDune");
    }
    
    public void ActiveOasisNPC()
    {
        oasisNpc.GetComponent<Interactor>().enabled = true;
        ActiveZoomCamera("FirstTimeOasis");
    }
    
    public void ActivePyramidNPC()
    {
        pyramidNpc.GetComponent<Interactor>().enabled = true;
        ActiveZoomCamera("FirstTimePyramid");
    }
    
    public void ActiveObeliskNPC()
    {
        obeliskNpc.GetComponent<Interactor>().enabled = true;
        ActiveZoomCamera("FirstTimeObelisk");
    }

    public void SendBackToMerchandNPC()
    {
        merchandNpc.GetComponent<DialogueManager>().enabled = true;
    }

    public void AddOneCoconut()
    {
        coconutsFound++;
        
        if (coconutsFound == 5)
        {
            ChangeObjective("Reparler à l'Apo de l'Oasis");
            
            oasisNpc.GetComponent<DialogueManager>().enabled = true;
        }
        else
        {
            ChangeObjective("Ramasser les noix de coco autour de l'Oasis " + coconutsFound + "/5");
        }
    }

    private IEnumerator StartQuest()
    {
        yield return new WaitForSeconds(1);
        BeginQuest();
    }

    private void ActiveZoomCamera(string zoom)
    {
        GameObject.Find(zoom).GetComponent<BoxCollider>().enabled = true;
        GameObject.Find(zoom).GetComponent<ZoomCamera>().enabled = true;
    }

    public void ActiveRepair()
    {
        spaceship.GetComponent<Interactor>().enabled = true;
    }

    public void FinishQuest()
    {
        questManager.Remove(this);
    }
}
