using UnityEngine;

public class F_QuestItem : MonoBehaviour, F_IInteractable
{
    public string questItemName;
    public void Interact()
    {
        F_EventController.Instance.TriggerOnQuestItemInterraction(questItemName);
        Destroy(gameObject);
    }
}
