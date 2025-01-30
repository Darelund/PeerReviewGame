using UnityEngine;

public class QuestItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string ItemName;
    public void Interact()
    {
        EventController.Instance.Interact(ItemName);
        Destroy(gameObject);
    }
}
