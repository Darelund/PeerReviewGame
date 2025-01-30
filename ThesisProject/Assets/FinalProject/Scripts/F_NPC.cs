using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_NPC : MonoBehaviour, F_IInteractable
{
    [SerializeField] F_SO_Dialogue dialogue;
    public void Interact()
    {
        F_DialogueManager.Instance.QueueDialogue(dialogue);
    }
}
