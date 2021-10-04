using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLevel(int levelnum)
    {
        SceneManager.LoadScene(levelnum);
    }

    public void QuitGame()
    {
        Debug.Log("Program Quitting...");
        Application.Quit();
    }
}
