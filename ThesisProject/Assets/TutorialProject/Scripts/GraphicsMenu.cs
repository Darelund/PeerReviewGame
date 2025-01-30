using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    GameObject playerObject; 
    [SerializeField] TMP_Dropdown resolutionDropDown; // A reference to our resolutions drop down UI element
    [SerializeField] TMP_Dropdown fpsDropDown;
    [SerializeField] Slider mouseSensitivitySlider;//access to slider its value 
    [SerializeField] TMP_Text sensitivityValueTxt; //display the current value of the slider
    Resolution[] resolutions;
    List<string> fpsOptions;

    public void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        PopulateResDropDown();
    }

    public void ChangeSensitivity()
    {
        int newSensitivity = (int)mouseSensitivitySlider.value;
        sensitivityValueTxt.text = newSensitivity.ToString();
       // playerObject.GetComponent<PlayerLook>().MouseSensitivity = newSensitivity;
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void TogglePOV()
    {
        // Screen.fullScreen = !Screen.fullScreen;
        GameObject.FindFirstObjectByType<PlayerLook>().SwitchCamera();
    }

    public void PopulateResDropDown()
    {
        int currentResIndex = 0;

        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        for (int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].width + "x" + resolutions[i].height);
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
        PopulateFpsDropDown();
    }


    public void ChangeFps(int fpsIndex)
    {
        // Get the selected FPS from the dropdown
       // var newFps = fpsOptions[fpsIndex];
        int selectedRefreshRate = int.Parse(fpsDropDown.options[fpsIndex].text.Replace("FPS", ""));
        Application.targetFrameRate = selectedRefreshRate;

        // Get the current resolution
        //int width = Screen.currentResolution.width;
        //int height = Screen.currentResolution.height;

        //// Set the resolution with the selected refresh rate

        ////TODO Make it work with RefreshRate struct instead of it
        //Screen.SetResolution(width, height, Screen.fullScreen, selectedRefreshRate);

        //Debug.Log($"Resolution: {width}x{height}, Refresh Rate: {selectedRefreshRate} Hz");
    }
    public void PopulateFpsDropDown()
    {
        fpsOptions = new List<string>();
        //Resolution[] resolutions = Screen.resolutions;
       // int currentResIndex = 0;


        //int currentResWidth = Screen.currentResolution.width;
        //int currentResHeight = Screen.currentResolution.height;
        fpsOptions.Add(30 + "FPS");
        fpsOptions.Add(60 + "FPS");
        fpsOptions.Add(100 + "FPS");
        fpsOptions.Add(200 + "FPS");
        fpsOptions.Add(Application.targetFrameRate + "FPS");

        //// Get refresh rates for the current resolution
        //foreach (var fps in fpsOptions)
        //{
        //    if (int.Parse(fps) == Application.targetFrameRate)
        //    {
        //    }
        //}


        // Populate the dropdown (assuming you have a dropdown called fpsDropDown)
        fpsDropDown.ClearOptions();
        fpsDropDown.AddOptions(fpsOptions);
        resolutionDropDown.value = fpsOptions.Count - 1;
        fpsDropDown.RefreshShownValue();
    }
}
