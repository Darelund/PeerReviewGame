using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class F_QuestGiver : MonoBehaviour, F_IInteractable
{
    public F_Quest quest; // Holds the quest this object can give.
    [SerializeField] GameObject questWindow; // The UI panel that displays the quest details.
    [SerializeField] TMP_Text titleText; // UI text component for displaying the quest's title.
    [SerializeField] TMP_Text descriptionText; // UI text component for displaying the quest's description.
    [SerializeField] TMP_Text rewardText; // UI text component for displaying the quest's reward.

    private void Start()
    {
        // Initialize each goal associated with the quest.
        for (int i = 0; i < quest.goals.Count; i++) {
            quest.goals[i].Init();
        }
    }

    // Method defined in the IInteractable interface, called to interact with this object.
    public void Interact()
    {
        OpenQuestWindow();
    }

    // Opens and sets up the quest window UI.
    private void OpenQuestWindow()
    {
        // If the quest was already accepted, the window won't open.
        if(quest == null) return;
        // Disables the player's input and makes the cursor visible and unlocked for UI interaction.
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Activate the quest window and populate its fields with quest data.
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        rewardText.text = "Reward: " + quest.reward.ToString() + " gold";
    }

    // Closes the quest window and restores the player's input and cursor settings.
    public void CloseQuestWindow()
    {
        // Re-enables the player's input and hides and locks the cursor for normal gameplay.
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        questWindow.SetActive(false);
    }

    // Marks the quest as active and adds it to the player's list of active quests.
    public void AcceptQuest()
    {
        quest.isActive = true;
        // Adds the quest to the player's list of active quests and checks the quest status.
        GameObject.FindWithTag("Player").GetComponent<F_PlayerQuests>().activeQuests.Add(quest);
        GameObject.FindWithTag("Player").GetComponent<F_PlayerQuests>().CheckQuests(); // This is called in case we completed all goals before we accept the quest.
        quest = null;
    }
}
