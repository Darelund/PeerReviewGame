using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{

    private bool inDialogue;
    private bool isTyping;
    private Queue<Info> dialogueQueue; 
    private string completeText; 
    [SerializeField] private float textDelay = 0.1f; 
    
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject dialogueBox;

    private static DialogueManager instance;
    public static DialogueManager Instance { get => instance; private set => instance = value; }


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

        dialogueQueue = new Queue<Info>();
    }

    private IEnumerator TypeText(Info info)
    {
        //dialogueBox.SetActive(true);
        //dialogueText.text = "";
        isTyping = true;
        foreach (var c in info.Dialogue.ToCharArray())
        {
            yield return new WaitForSeconds(textDelay);
            dialogueText.text += c.ToString();
        }
        isTyping = false;
    }
    private void EndDialogue()
    {
        //Turn on player
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;

        inDialogue = false;
        dialogueBox.SetActive(false);
    }
    private void CompleteText()
    {
        dialogueText.text = completeText;
    }
    public void Skip(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if (inDialogue)
            {
                DequeueDialogue();
            }
        }
    }
    public void QueueDialogue(DialogueSO dialogue)
    {
        if (inDialogue) return;


        inDialogue = true;
        dialogueBox.SetActive(true);
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;

        //Shouldn't be needed, but lets have it anyways
        dialogueQueue.Clear();

        foreach (var dialog in dialogue.DialogueInfo)
        {
            dialogueQueue.Enqueue(dialog);
        }
        //To start first dialog
        DequeueDialogue();
    }
    private void DequeueDialogue()
    {
        if(isTyping) //To know if we should complete text or not
        {
            CompleteText();
            StopAllCoroutines();
            isTyping = false;
            return;
        }
        if(dialogueQueue.Count <= 0)
        {
            EndDialogue();
            return;
        }
        var newInfo = dialogueQueue.Dequeue();
        completeText = newInfo.Dialogue;
        dialogueText.text = "";
        StartCoroutine(TypeText(newInfo));
    }
}
