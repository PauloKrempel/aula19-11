using System.Collections;
using System.Collections.Generic;
using QuestSystem.Player;
using UnityEngine;
using TMPro;
using QuestSystem.Quest;
using UnityEngine.UI;

public class QuestBoard : MonoBehaviour
{
    public GameObject questWindow;
    public GameObject listMissions;
    public Quest quest;
    public PlayerStatus player;
    private PlayerQuest _playerQuest;
    public GameObject acceptButton;
    public GameObject inProgress;
    
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text experienceText;
    public TMP_Text goldText;
    public Button btn;

    public void OpenQuest()
    {
        
        listMissions.SetActive(false);
        questWindow.SetActive(true);

        titleText = questWindow.transform.Find("TitleQuest").GetComponent<TMP_Text>();
        descriptionText = questWindow.transform.Find("description").GetComponent<TMP_Text>();
        goldText = questWindow.transform.Find("ouro").GetComponent<TMP_Text>();
        experienceText = questWindow.transform.Find("xp").GetComponent<TMP_Text>();
        
        
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.experienceReward.ToString();
        goldText.text = quest.goldReward.ToString();

        PlayerQuest.Instance.currentQuest = quest;
        if (quest.isActive)
        {
            acceptButton.SetActive(false);
            inProgress.SetActive(true);
        }
        else
        {
            acceptButton.SetActive(true);
            inProgress.SetActive(false);
        }
    }
    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
        _playerQuest.Add(quest);
    }

    
}
