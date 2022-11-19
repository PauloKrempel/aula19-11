using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestBoard : MonoBehaviour
{
    public GameObject questWindow;
    public GameObject listMissions;
    public Quest quest;
    public PlayerStatus player;
    
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text experienceText;
    public TMP_Text goldText;

    public void OpenQuest()
    {
        
        listMissions.SetActive(false);
        //questWindow = GameObject.Find("QuestW");
        questWindow.SetActive(true);
        //quest = questWindow.transform.Find("questSelect").GetComponent<Quest>();
        
        titleText = questWindow.transform.Find("TitleQuest").GetComponent<TMP_Text>();
        descriptionText = questWindow.transform.Find("description").GetComponent<TMP_Text>();
        goldText = questWindow.transform.Find("ouro").GetComponent<TMP_Text>();
        experienceText = questWindow.transform.Find("xp").GetComponent<TMP_Text>();
        
        
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.experienceReward.ToString();
        goldText.text = quest.goldReward.ToString();
    }
    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
        player.Add(quest);
    }
}
