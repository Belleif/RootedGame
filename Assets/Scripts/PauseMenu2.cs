using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu2 : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    //public PauseMenu2 gameObject;

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        //gameObject.GetComponent<PauseMenu>()
        //gameObject.enabled = false;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void ResetLevel(int CurrentLevel)
    {
       //----------Input Fade To Black Call Method

        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentLevel);
    }

    public void SettingsMenu()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }
    public void QuitGame()
    {
        Application.OpenURL("https://forms.gle/tAGG6oq7hMpBAWyx8");
        Debug.Log("Program Quitting...");
        Application.Quit();
    }
}
