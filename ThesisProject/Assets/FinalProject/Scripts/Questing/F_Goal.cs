using UnityEngine;

// A system attribute to allow this class to be visible and serialized in the Unity inspector.
[System.Serializable]
public class F_Goal
{
    // Enum representing the type of goal.
    public GoalType goalType;
    // The specific name of the objective this goal is monitoring.
    public string objectiveName;
    // A bool to check if the goal has been completed.
    public bool completed;
    // Current progress towards the goal.
    public int currentAmount;
    // The total amount needed to complete the goal.
    public int requiredAmount;

    // Initialize the goal, setting up necessary event listeners based on the goal type.
    public void Init()
    {
        switch (goalType)
        {
            case GoalType.Interact:// If the goal type is to interact with an object, subscribe to the appropriate event.
                F_EventController.Instance.OnQuestItemInterraction += ObjectInteracted;
                break;
            case GoalType.Kill:
                break;// TO DO: Expand this section as you add more goal types.
        }
    }

    void ObjectInteracted(string objectName)
    {
        // Check if the interacted object is the target objective.
        if (objectName == objectiveName)
        {
            // Increment the progress of the goal.
            currentAmount++;
            // Re-evaluate the goal's completion status.
            Evaluate();
        }
    }
    // Evaluate the current progress of the goal to determine if it has been met.
    public void Evaluate()
    {
        // If the current amount reaches or exceeds the required amount, complete the goal.
        if (currentAmount >= requiredAmount)
        {
            completed = true;
            // Check if there are now any quests completed.
            GameObject.FindWithTag("Player").GetComponent<F_PlayerQuests>().CheckQuests();
            Debug.Log("Goal of type " + goalType + " completed");
        }
    }
}

// Define the types of goals that can exist within the game. You can expand this in the future.
public enum GoalType
{
    Interact, // Goal requires interacting with specific objects.
    Kill      // Goal requires killing certain entities.
}
