using System.Collections.Generic;
using UnityEngine;

public class F_PlayerQuests : MonoBehaviour
{
    // A list to hold all quests that the player is currently undertaking.
    public List<F_Quest> activeQuests;

    // Method to check the completion status of all active quests.
    public void CheckQuests()
    {
        // Iterate through each quest in the list of active quests.
        for (int i = 0; i < activeQuests.Count; i++)
        {
            // If the current quest is not active, skip further checks for this quest.
            if (!activeQuests[i].isActive) break;

            // A flag to track if all goals within a quest are completed.
            bool allGoalsCompleted = true;

            // Iterate through each goal in the current quest.
            for(int j = 0; j < activeQuests[i].goals.Count; j++)
            {
                // If any goal is not completed, set the flag to false and stop checking further goals.
                if (!activeQuests[i].goals[j].completed)
                {
                    allGoalsCompleted = false;
                    break; // No need to check further goals if one is incomplete, optimizes performance.
                }
            }

            // If all goals for the current quest are completed,
            if(allGoalsCompleted)
            {
                // Call the CompleteQuest method to mark the quest as inactive and get the reward.
                activeQuests[i].CompleteQuest();
            }
        }
    }
}
