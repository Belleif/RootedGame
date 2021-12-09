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
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        //gameObject.GetComponent<PauseMenu>()
        //gameObject.enabled = false;
    }

    public void LoadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
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
     //   Application.OpenURL("https://forms.gle/tAGG6oq7hMpBAWyx8");
        Debug.Log("Program Quitting...");
        Application.Quit();
    }

    IEnumerator Waiter(int levelNum)
    {
        //The seconds are hard coded, which isn't the most elegant solution
        //But buttons only allow for a single parameter in OnClick functions
        //You'll have to either find out how long the clip is or play around with the wait
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene(levelNum);
    }
}
