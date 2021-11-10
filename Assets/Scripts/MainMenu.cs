using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public SettingsMenu settings;


    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        mainMenu.active = true;
        settingsMenu.active = false;
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
    }

    public void SettingsMenu()
    {
        mainMenu.active = false;
        settingsMenu.active = true;
    }

    public void BackButton()
    {
        mainMenu.active = true;
        settingsMenu.active = false;
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

