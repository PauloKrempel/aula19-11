using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using QuestSystem.Quest;

public class QuestGiver : MonoBehaviour
{
    public Quest[] quest;
    public int currentQuest;
    public PlayerStatus player;
    public GameObject questWindow;
    public bool questActive;

    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text experienceText;
    public TMP_Text goldText;
    
    public void OpenQuestWindow()
    {
        foreach (Quest verifierActiveQuest in quest)
        {
            if (verifierActiveQuest.isActive)
            {
                Debug.Log("A quest esta ativa");
                break;
            }
            else if(verifierActiveQuest.isActive == false && !questActive)
            {
                RandomQuest();
            }
        }
        
        questWindow.SetActive(true);
        titleText.text = quest[currentQuest].title;
        descriptionText.text = quest[currentQuest].description;
        experienceText.text = quest[currentQuest].experienceReward.ToString();
        goldText.text = quest[currentQuest].goldReward.ToString();
    }

    public void RandomQuest()
    {
        currentQuest = Random.Range(0, quest.Length);
        Debug.Log("A quest escolhida é: " + quest[currentQuest].title);
    }

    //Varias missões é necessário adicionar uma lista
    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest[currentQuest].isActive = true;
        player.quest = quest[currentQuest];
        questActive = true;
    }
}
