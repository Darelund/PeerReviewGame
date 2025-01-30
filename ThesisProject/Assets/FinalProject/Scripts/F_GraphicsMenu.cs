using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class F_GraphicsMenu : MonoBehaviour
{
    GameObject playerObject; //a reference to the player object to gain access to its components
    [SerializeField] TMP_Dropdown resolutionDropDown; // A reference to our resolutions drop down UI element
    [SerializeField] Slider mouseSensitivitySlider;//A reference to our mouse sensitivity slider to get access to its value 
    [SerializeField] TMP_Text sensitivityValueTxt; //A reference to mouse sensitivity value text object to display the current value of the slider
    Resolution[] resolutions ;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        PopulateResDropDown();
    }

    public void ChangeSensitivity()
    {
        int newSensitivity = (int)mouseSensitivitySlider.value; //save the value of the sensitivity slider
        sensitivityValueTxt.text = newSensitivity.ToString(); // displays the new value in text form
        playerObject.GetComponent<F_PlayerLook>().mouseSensitivity = newSensitivity; // changes the players sensitivity ingame
    }

    public void ToggleFullScreen()
    {
         Screen.fullScreen = !Screen.fullScreen;
    }
    public void PopulateResDropDown()
    {
        int currentResIndex = 0;

        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        for (int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].width+ "x" + resolutions[i].height );
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResIndex = i;
            }
        }

        resolutionDropDown.ClearOptions();
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void ChangeResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
