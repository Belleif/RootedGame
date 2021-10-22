using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
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
        Application.OpenURL("https://forms.gle/tAGG6oq7hMpBAWyx8");
        Debug.Log("Program Quitting...");
        Application.Quit();
    }
}
