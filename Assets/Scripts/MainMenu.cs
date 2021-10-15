using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
    }

    public void LoadLevel(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
    }


    public void QuitGame()
    {
        Debug.Log("Program Quitting...");
        Application.Quit();
    }
}
