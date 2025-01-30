using System;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public event Action<string> OnItemInteraction;

    private static EventController instance;
    public static EventController Instance { get => instance; private set => instance = value; }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Interact(string ItemName)
    {
        OnItemInteraction?.Invoke(ItemName);
    }
}
