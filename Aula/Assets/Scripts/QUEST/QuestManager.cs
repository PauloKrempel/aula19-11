using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public List<Quest> quests = new List<Quest>();
    
    public Transform questContent;
    public GameObject mission;
    public QuestMissionController[] QuestMission;
    public Button[] buttonsMission;
    public GameObject MissionBoardGo;
    public GameObject QuestBoard;

    private void Awake()
    {
        Instance = this;
        
    }
    public void Add(Quest quest)
    {
        quests.Add(quest);
    }
    public void ListQuest()
    {
        // if (QuestMission.Length >= quests.Count)
        // {
        //     System.Array.Clear(questContent.GetComponentsInChildren<QuestMissionController>(),0, quests.Count);
        //     QuestMission = System.Array.Empty<QuestMissionController>();
        //     
        //     print("Limpei");
        // }
        // foreach (Transform quest in questContent)
        // {
        //     Destroy(quest.gameObject);
        // }
        if (QuestMission.Length < quests.Count)
        {
            print("temos: " + quests.Count);
            print("há : " + QuestMission.Length);
            foreach (var quest in quests)
            {
                GameObject obj = Instantiate(mission, questContent);
                var questName = obj.transform.Find("QuestTitle").GetComponent<TMP_Text>();
            
                questName.text = quest.title;
            }
            SetInventoryItems();
        }
        //verificar se a missão foi finalizada...
        
        
    }
    public void SetInventoryItems()
    {
        QuestMission = questContent.GetComponentsInChildren<QuestMissionController>();
        buttonsMission = questContent.GetComponentsInChildren<Button>();

        for (int i = 0; i < quests.Count; i++)
        {
            QuestMission[i].AddQuest(quests[i]);
            buttonsMission[i].GetComponent<QuestBoard>().quest = quests[i];
            buttonsMission[i].GetComponent<QuestBoard>().questWindow = QuestBoard;
            buttonsMission[i].GetComponent<QuestBoard>().listMissions = MissionBoardGo;
        }
    }
    
}
