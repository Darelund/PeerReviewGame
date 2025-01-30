using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string title;
    public string description;
    public string reward;

    public List<Goal> goalList;
    public bool isActive;

    public void CompleteQuest()
    {
        isActive = false;
        Debug.Log(title + " was completed");
        //Give thingy to player?
    }
}
