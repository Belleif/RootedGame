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
    int currentResolutionIndex = 0;// Moved this one out of resolution selection
    public int fullscreencheck;
    Resolution[] resolutions;

    void Start()
    {
        
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        resolutions = Screen.resolutions;
        Debug.Log(resolutions.Length);
        
        for (int i =0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " : " + resolutions[i].refreshRate + " hz";
            options.Add(option);
            Debug.Log(option);
            //int Current resolution index was moved from here
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height && Screen.currentResolution.refreshRate == resolutions[i].refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("VolumePreference", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityPreference", qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        //Should convert true and false to int values
        if(isFullscreen)
        {
            fullscreencheck = 1;
        }
        else
        fullscreencheck = 0;
        PlayerPrefs.SetInt("FullscreenPreference", fullscreencheck);
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

        if (PlayerPrefs.HasKey("QualityPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualityPreference");
        else
            qualityDropdown.value = 5;

        if (PlayerPrefs.HasKey("FullscreenPreference"))
            fullscreencheck = PlayerPrefs.GetInt("QualityPreference");
        else
            fullscreencheck = 0;
    }

    //For In-Game Pause Menu ONLY!
    public void BackButton()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }
}
