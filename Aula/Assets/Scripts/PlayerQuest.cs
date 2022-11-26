using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace QuestSystem.Player
{
    using Quest;
    public class PlayerQuest : Singleton<PlayerQuest>
    {
        public int Experience = 0;
        public int Level;
        public List<Quest> ListQuests = new List<Quest>();
        public Quest currentQuest;
        
        [Header("Missões")]
        public Transform questContent;
        public GameObject mission;
        public QuestMissionController[] QuestMission;
        public Button[] buttonsMission;
        public GameObject MissionBoardGo;
        public GameObject QuestBoard;
        //public Button acceptBtn;
        public GameObject acceptButton;
        public GameObject inProgress;

        private void Start()
        {
            MissionBoardGo.SetActive(false);
        }

        public void Add(Quest quest)
        {
            ListQuests.Add(quest);
        }
        public void QuestAccept()
        {
            if (currentQuest.isActive != true)
            {
                Add(currentQuest);
                currentQuest.isActive = true;
            }
        }

        public void OpenListQuest()
        {
            MissionBoardGo.SetActive(true);
            if (QuestMission.Length < ListQuests.Count)
            {
                foreach (var quest in ListQuests)
                {
                    GameObject obj = Instantiate(mission, questContent);
                    var questName = obj.transform.Find("QuestTitle").GetComponent<TMP_Text>();
                
                    questName.text = quest.title;
                    
                }
                SetInventoryItems();
            }
        }
        public void SetInventoryItems()
        {
            QuestMission = questContent.GetComponentsInChildren<QuestMissionController>();
            buttonsMission = questContent.GetComponentsInChildren<Button>();
    
            for (int i = 0; i < ListQuests.Count; i++)
            {
                QuestMission[i].AddQuest(ListQuests[i]);
                buttonsMission[i].GetComponent<QuestBoard>().quest = ListQuests[i];
                buttonsMission[i].GetComponent<QuestBoard>().questWindow = QuestBoard;
                buttonsMission[i].GetComponent<QuestBoard>().listMissions = MissionBoardGo;
                //buttonsMission[i].GetComponent<QuestBoard>().btn = acceptBtn;
                buttonsMission[i].GetComponent<QuestBoard>().acceptButton = acceptButton;
                buttonsMission[i].GetComponent<QuestBoard>().inProgress = inProgress;

            }
        }
    }
}

