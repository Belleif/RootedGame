using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public SettingsMenu settings;
    public GameObject checkpointsDisabled;
    public GameObject checkpointsEnabled;
    public static int oneComplete;
    public static int twoComplete;
    public static int threeComplete;
    public static int fourComplete;
    public static int fiveComplete;
    public static int sixComplete;
    public static int sevenComplete;
    public static int eightComplete;
    //Not elegant I know


    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        checkpointsDisabled.SetActive(true);
        checkpointsEnabled.SetActive(false);
        settings.LoadSettings();
    }
    
    public void PlayGame(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
        //StartCoroutine(Waiter(levelNum));
    }

    public void LoadLevel(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
        // StartCoroutine(Waiter(levelNum));
        if (PlayerPrefs.GetInt("OneDone") == 1)
        {
            checkpointsDisabled.SetActive(false);
            checkpointsEnabled.SetActive(true);
        }


    }

    public void SettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void BackButton()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }


    public void QuitGame()
    {
        Application.OpenURL("https://forms.gle/tAGG6oq7hMpBAWyx8");
        Debug.Log("Program Quitting...");
        Application.Quit();
    }

    //IEnumerator Waiter(int levelNum)
    //{
        //The seconds are hard coded, which isn't the most elegant solution
        //But buttons only allow for a single parameter in OnClick functions
        //You'll have to either find out how long the clip is or play around with the wait
        //while (true)
        //{
           // yield return new WaitForSeconds(.2f);
            //SceneManager.LoadScene(levelNum);
        //}
        
    //}
}

