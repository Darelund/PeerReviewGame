using UnityEngine;

[System.Serializable]
public class Goal
{
    public GoalType Type;
    public string ObjectiveName;
    public int CurrentAmount;
    public int RequiredAmount;

    public bool isCompleted = false;

    public void Init()
    {
        switch (Type)
        {
            case GoalType.Interact:
                EventController.Instance.OnItemInteraction += InteractedWithObject;
                break;
            case GoalType.Kill:
                break;
        }
    }

    public void HasReachedGoal()
    {
        if(CurrentAmount >= RequiredAmount)
        {
            isCompleted = true;
            Debug.Log("You reached the goal!");
            GameObject.FindWithTag("Player").GetComponent<PlayerQuests>().CheckQuests();
        }
    }

    public void InteractedWithObject(string objectName)
    {
        if(objectName == ObjectiveName)
        {
            CurrentAmount++;
            HasReachedGoal();
        }
    }
}