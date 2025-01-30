using System.Collections.Generic;
using UnityEngine;

// A system attribute to allow this class to be visible and serialized in the Unity inspector.
[System.Serializable]
public class F_Quest
{
    public bool isActive;  // Bool to determine if the quest is currently active.

    public string title;  // The title of the quest.
    public string description;  // A description of what the quest entails.
    public int reward;  // The reward given upon completion of the quest.

    public List<F_Goal> goals;  // A list of goals that need to be completed to finish the quest.

    // Method to mark the quest as completed.
    public void CompleteQuest()
    {
        isActive = false;  // Set the quest's active status to false indicating completion.
        Debug.Log(title + " was completed");
        // TO DO: Give the player reward. 
    }
}
