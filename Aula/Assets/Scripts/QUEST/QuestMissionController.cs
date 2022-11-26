using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem.Quest;
public class QuestMissionController : MonoBehaviour
{
    private Quest quest;

    public void RemoveQuest(Quest quest)
    {
        
    }
    public void AddQuest(Quest newQuest)
    {
        quest = newQuest;
    }
}
