using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestGiver : MonoBehaviour, IInteractable
{
    [SerializeField] private Quest quest;
    [SerializeField] private GameObject questWindow;

    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text rewardText;

    [SerializeField] private GameObject questPaper;


    public void Start()
    {
        foreach (var g in quest.goalList)
        {
            g.Init();
        }
    }
    public void Interact()
    {
        OpenQuestWindow();
    }
    private void OpenQuestWindow()
    {
        if (quest == null) return; //Only open if it has a quest to give you

        //Window stuff
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        rewardText.text = $"Reward: {quest.reward} Gold";

        //Player stuff
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

       
    }
    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void AcceptQuest()
    {
        quest.isActive = true;
        // Adds the quest to the player's list of active quests and checks the quest status.
        GameObject.FindWithTag("Player").GetComponent<PlayerQuests>().CurrentQuests.Add(quest);
        GameObject.FindWithTag("Player").GetComponent<PlayerQuests>().CheckQuests(); // This is called in case we completed all goals before we accept the quest.
        quest = null;
        Destroy(questPaper);
        CloseQuestWindow();
    }
}
