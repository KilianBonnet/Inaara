using System.Collections;
using UnityEngine;

public class EnterSpaceshipQuest : Quest
{
    // Start is called before the first frame update
    public override void BeginQuest()
    {
        StartCoroutine(StartDelayed());
    }


    private IEnumerator StartDelayed()
    {
        yield return new WaitForSeconds(1);
        
        questName = "A l'bordage!";
        questDescription = "Rejoindre le vaisseau";
        questManager.Add(this);
    }

    private void Awake()
    {
        BeginQuest();
        DontDestroyOnLoad(gameObject);
    }

    public void EndQuest()
    {
        questManager.Remove(this);
        Destroy(gameObject);
    }
}
