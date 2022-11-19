using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmout;

    public bool IsReached()
    {
        return (currentAmout >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if (goalType == GoalType.Kill)
        {
            currentAmout++;
        }
    }
    public void ItemCollected()
    {
        if (goalType == GoalType.Gathering)
        {
            currentAmout++;
        }
    }
}

public enum GoalType
{
    Kill,
    Gathering
}
