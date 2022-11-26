using System;
using System.Collections;
using System.Collections.Generic;
using QuestSystem.Player;
using UnityEngine;
using QuestSystem.Quest;
public class PlayerStatus : MonoBehaviour
{
    public int health = 5;
    public int experience = 40;
    public int gold = 100;

    public Quest quest;
    private List<Quest> quests = new List<Quest>();
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerQuest.Instance.OpenListQuest();
        }
    }

    public void GoBattle()
    {
        health -= 1;
        experience += 2;
        gold += 5;

        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                experience += quest.experienceReward;
                gold += quest.goldReward;
                quest.Complete();
            }
        }
    }
    public void Add(Quest quest)
    {
        quests.Add(quest);
    }
}
