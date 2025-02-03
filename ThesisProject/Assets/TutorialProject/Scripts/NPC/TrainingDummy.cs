using UnityEngine;

public class TrainingDummy : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("What are you looking at?");
    }
}
