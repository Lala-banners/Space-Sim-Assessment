using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    /* Options Menu 
     * Resolution
     * Change colour depth buffer (Camera.SetTargetBuffers)
     * Anti-Aliasing
     * Anisotropic Filtering
     * Frame rate limiter
     */
    
    #region Options Menu UI
    [Header("Menu Object")]
    public GameObject optionsMenu;
    public GameObject mainMenu;
    
    [Header("Quality Settings")]
    public TMP_Dropdown qualityDropdown;
    public Toggle fullscreenToggle;

    [Space]
    
    [Header("Resolution Settings")]
    public Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    [Space]
    
    [Header("Buttons")]
    public Button back;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetUpResolution();
        LoadPlayerPrefs();
        FullscreenPrefs();
        QualityPrefs();
        
        back.onClick.AddListener(() => {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
        });
    }
    
    public void FullscreenPrefs() {
        if (!PlayerPrefs.HasKey("fullscreen"))
        {
            PlayerPrefs.SetInt("fullscreen", 0); 
            Screen.fullScreen = false;
        }
        else
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                Screen.fullScreen = false;
            }
            else
            {
                Screen.fullScreen = true;
            }
        }
    }

    public void QualityPrefs() {
        if (!PlayerPrefs.HasKey("quality"))
        {
            PlayerPrefs.SetInt("quality", 5);
            QualitySettings.SetQualityLevel(5);
        }
        else
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
        }
        PlayerPrefs.Save();
    }

    #region Change Settings
    public void SetFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    //This changes the quality 
    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetUpResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) //Go through every resolution
        {
            //Build a string for displaying the resolution
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                //We have found the current screen resolution, save that number.
                currentResolutionIndex = i;
            }
        }
        //Set up our dropdown
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionindex)
    {
        Resolution res = resolutions[resolutionindex];
        Screen.SetResolution(res.width, res.height, false);
    }
    #endregion

    #region Save Prefs
    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());
        PlayerPrefs.SetInt("quality", qualityDropdown.value);
        if (fullscreenToggle.isOn)
        {
            PlayerPrefs.SetInt("fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0);
        }

        PlayerPrefs.Save();
    }
    #endregion

    #region Load Prefs
    public void LoadPlayerPrefs()
    {
        //Load Quality
        if (PlayerPrefs.HasKey("quality"))
        {
            int quality = PlayerPrefs.GetInt("quality");
            qualityDropdown.value = quality;
            if (QualitySettings.GetQualityLevel() != quality)
            {
                ChangeQuality(quality);
            }
        }
        //load fullscreen
        if (PlayerPrefs.HasKey("fullscreen"))
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                fullscreenToggle.isOn = false;
            }
            else
            {
                fullscreenToggle.isOn = true;
            }
        }
    }
    #endregion
}
