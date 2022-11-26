using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace QuestSystem.Quest
{
    [CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Create New Quest")]
    [System.Serializable]
    public class Quest : ScriptableObject
    {
        public int id;
        public int level;
        public bool isActive;

        public string title;
        public string description;
        public int experienceReward;
        public int goldReward;

        public QuestGoal goal;

        public void Complete()
        {
            isActive = false;
        }
    }
}

