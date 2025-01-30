using System.Collections.Generic;
using UnityEngine;

public class PlayerQuests : MonoBehaviour
{
    public List<Quest> CurrentQuests = new List<Quest>(); //Accepted quests

    public void CheckQuests()
    {
        for (int i = 0; i < CurrentQuests.Count; i++)
        {
            if (!CurrentQuests[i].isActive) continue; // don't check quests that are not active, should remove them

            bool allGoalsCompleted = true;
            foreach (var goal in CurrentQuests[i].goalList)
            {
                if(!goal.isCompleted)
                {
                    //If we encounter a quest that has 1 or more goals that are not completed than we should not check it.
                    //Because it is obviously not complete.
                    allGoalsCompleted = false;
                    break;
                }
            }
            //If we have come this far then it much be finished
            if(allGoalsCompleted)
            CurrentQuests[i].CompleteQuest();
        }
    }
}
