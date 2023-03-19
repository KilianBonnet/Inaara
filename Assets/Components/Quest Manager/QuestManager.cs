using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public struct QuestUi
{
    public GameObject root;
    public TextMeshProUGUI name;
    public TextMeshProUGUI descriprion;
}


public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject questUiPrefab;
    private Dictionary<Quest, QuestUi> quests = new();
    private AudioSource questSound;

    private void Start()
    {
        questSound = GetComponent<AudioSource>();
    }

    public void Add(Quest quest)
    {
        GenerateUI(quest);
        questSound.Play();
    }

    public void Remove(Quest quest)
    {
        Destroy(quests[quest].root);
        quests.Remove(quest);
    }

    public void Refresh(Quest quest)
    {
        QuestUi ui = quests[quest];
        ui.name.text = quest.questName;
        ui.descriprion.text = quest.questDescription;
    }

    private void GenerateUI(Quest quest)
    {
        QuestUi questUi = new QuestUi();
        questUi.root = Instantiate(questUiPrefab, transform);
        
        foreach (Transform child in questUi.root.transform)
        {
            switch (child.gameObject.name)
            {
                case "Quest Title":
                    questUi.name = child.gameObject.GetComponent<TextMeshProUGUI>();
                    questUi.name.text = quest.questName;
                    break;
                case "Quest Description":
                    questUi.descriprion = child.gameObject.GetComponent<TextMeshProUGUI>();
                    questUi.descriprion.text = quest.questDescription;
                    break;
            }
        }
        
        quests.Add(quest, questUi);
    }
}
