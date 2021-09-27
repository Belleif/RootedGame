using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu2 : MonoBehaviour
{

    //public PauseMenu2 gameObject;

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        //gameObject.GetComponent<PauseMenu>()
        //gameObject.enabled = false;
    }

    public void QuitGame()
    {
        Debug.Log("Program Quitting...");
        Application.Quit();
    }
}
