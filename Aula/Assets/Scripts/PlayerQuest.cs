using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace QuestSystem.Player
{
    using Quest;
    public class PlayerQuest : Singleton<PlayerQuest>
    {
        public int Experience = 0;
        public int Level;
        public List<Quest> ListQuests = new List<Quest>();

        public void Add(Quest quest)
        {
            ListQuests.Add(quest);
        }
    }
}

