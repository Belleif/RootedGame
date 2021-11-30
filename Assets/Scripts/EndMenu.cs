using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void MainMenu(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.OpenURL("https://forms.gle/tAGG6oq7hMpBAWyx8");
        Debug.Log("Program Quitting...");
        Application.Quit();
    }
}
