using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
