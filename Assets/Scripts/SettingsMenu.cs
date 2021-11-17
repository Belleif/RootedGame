using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//////
/*
 * This script is for the Settings Menu. The controls here are meant to add a volume
 * 
 * REQUIREMENTS:
 *              - Audio Mixer that controls the general sound of the game
 *              - dropdown box for a Resolution list
 * How to use:
 *              - Place the script on the placeholder empty for the Settings Menu.
 *              - Drag the intended Audio Mixer into 
 * 
 */
//////
public class SettingsMenu : MonoBehaviour
{
    //For In-Game Pause Menu ONLY!
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Slider volume;
    public Dropdown qualityDropdown;
    public Toggle FullscreenToggle;
    public int currentResolutionIndex = 0;
    public int fullscreencheck;
    Resolution[] resolutions;
    public Slider sensitivity;


    void Start()
    { 
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        LoadSettings();

        if (PlayerPrefs.GetInt("FullscreenPreference", fullscreencheck) == 1)
            FullscreenToggle.isOn = true;
        else
            FullscreenToggle.isOn = false;

    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        Debug.Log("Set Res To Prefs");
    }

    public void SetVolume (float sliderVolume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(sliderVolume) * 20);
        PlayerPrefs.SetFloat("VolumePreference", sliderVolume);
        //Debug.Log("Set Vol To Prefs " + sliderVolume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityPreference", qualityIndex);
        //Debug.Log("Set Qual To Prefs " + qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        //Should convert true and false to int values
        if (isFullscreen)
        {
            fullscreencheck = 1;
        }
        else
        {
            fullscreencheck = 0;
        }
        PlayerPrefs.SetInt("FullscreenPreference", fullscreencheck);
    }

    public void SetSensitivity(float sliderSensitivity)
    {       
        sensitivity.value = sliderSensitivity;
        SC_TPSController.lookSpeed = sensitivity.value;
        PlayerPrefs.SetFloat("SensitivityPreference", sensitivity.value);
    } 

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;

        if (PlayerPrefs.HasKey("VolumePreference"))
           volume.value = PlayerPrefs.GetFloat("VolumePreference");
        else
            volume.value = 1.0f;

        if (PlayerPrefs.HasKey("SensitivityPreference"))
            sensitivity.value = PlayerPrefs.GetFloat("SensitivityPreference");
        else
            sensitivity.value = 1.0f; 

        if (PlayerPrefs.HasKey("QualityPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualityPreference");
        else
            qualityDropdown.value = 5;

        if (PlayerPrefs.HasKey("FullscreenPreference"))
            fullscreencheck = PlayerPrefs.GetInt("FullscreenPreference");
        else
            fullscreencheck = 0;    
        PlayerPrefs.Save();
    }


    //For In-Game Pause Menu ONLY!
    public void BackButton()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }
}
