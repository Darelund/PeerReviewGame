using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    //Dialog
    [SerializeField] private DialogueSO DialogueSO;
    public void Interact()
    {
        Debug.Log("Talking with npc");
        DialogueManager.Instance.QueueDialogue(DialogueSO);
    }
}
