using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private bool isPaused = false;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject pauseMenuObject; //Activate and deactive object
    [SerializeField] private GameObject pauseStartMenuObject; //Reference to StartMenu object because reset?
    [SerializeField] private GameObject parentMenu; //Parent of sub menus
    [SerializeField] private Animator animator;

    private void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
       // animator = GetComponent<Animator>();
        ResetPauseUI();
    }

    public void OnPauseGame(CallbackContext context)
    {
        if(context.started)
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                UnPauseGame();
            }
        }
    }
    public void PauseGame()
    {
        animator.SetBool("SwingIn", true);
    }
    public void PauseAfterAnimation()
    {
        isPaused = true;
        Time.timeScale = 0;
        //Disable player 
        playerGameObject.GetComponent<PlayerInput>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       // pauseMenuObject.SetActive(true);
    }
    public void UnPauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        //Disable player 
        playerGameObject.GetComponent<PlayerInput>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
      //  pauseMenuObject.SetActive(false);
        animator.SetBool("SwingIn", false);
       // ResetPauseUI();
    }
    public void ResetPauseUI()
    {
        for (int i = 0; i < parentMenu.transform.childCount; i++)
        {
            parentMenu.transform.GetChild(i).gameObject.SetActive(false);
        }
        pauseStartMenuObject.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false; //To close in editor mode, not build mode
    }
}
