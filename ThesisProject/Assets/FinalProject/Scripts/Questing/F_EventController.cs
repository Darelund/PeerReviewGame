using System;
using UnityEngine;

public class F_EventController : MonoBehaviour
{
    public static F_EventController Instance { get; private set; }
    public Action<string> OnQuestItemInterraction;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void TriggerOnQuestItemInterraction(string ItemName) 
    {
        OnQuestItemInterraction?.Invoke(ItemName); //sending interacted objects name to goals in order to check if its correct item
    }
}
