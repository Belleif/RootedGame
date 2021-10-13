using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(2);
    }


    public void QuitGame()
    {
        Debug.Log("Program Quitting...");
        Application.Quit();
    }
}
