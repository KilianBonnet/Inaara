using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject questUiPrefab;
    private List<Quest> quests = new();

    public void Add(Quest quest)
    {
        quests.Add(quest);
        Display(quest);
    }

    public void Remove(Quest quest)
    {
        quests.Remove(quest);
    }

    private void Display(Quest quest)
    {
        GameObject ui = Instantiate(questUiPrefab, transform);
        
        foreach (Transform child in ui.transform)
        {
            switch (child.gameObject.name)
            {
                case "Quest Title":
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = quest.questName;
                    break;
                case "Quest Description":
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = quest.questDescription;
                    break;
            }
        }
    }
}
