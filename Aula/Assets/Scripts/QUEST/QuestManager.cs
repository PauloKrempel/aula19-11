using System;
using System.Collections;
using System.Collections.Generic;
using QuestSystem.Player;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace QuestSystem.Manager
{
    using Quest;
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager Instance;
        public List<Quest> QuestsList = new List<Quest>();
        //private PlayerQuest _playerQuest;
        public Transform questContent;
        public GameObject mission;
        public QuestMissionController[] QuestMission;
        public Button[] buttonsMission;
        public GameObject MissionBoardGo;
        public GameObject QuestBoard;
        public Button acceptBtn;
        public GameObject acceptButton;
        public GameObject inProgress;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            foreach (Quest questInList in QuestsList)
            {
                if (questInList.isActive && !questInList.isCompleted)
                {
                    PlayerQuest.Instance.Add(questInList);
                }
            }
        }

        public void Add(Quest quest)
        {
            QuestsList.Add(quest);
        }
        public void ListQuest()
        {
            if (QuestMission.Length < QuestsList.Count)
            {
                foreach (var quest in QuestsList)
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
    
            for (int i = 0; i < QuestsList.Count; i++)
            {
                QuestMission[i].AddQuest(QuestsList[i]);
                buttonsMission[i].GetComponent<QuestBoard>().quest = QuestsList[i];
                buttonsMission[i].GetComponent<QuestBoard>().questWindow = QuestBoard;
                buttonsMission[i].GetComponent<QuestBoard>().listMissions = MissionBoardGo;
                buttonsMission[i].GetComponent<QuestBoard>().btn = acceptBtn;
                buttonsMission[i].GetComponent<QuestBoard>().acceptButton = acceptButton;
                buttonsMission[i].GetComponent<QuestBoard>().inProgress = inProgress;

            }
        }
    }
}