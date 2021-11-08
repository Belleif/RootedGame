using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoading : MonoBehaviour
{

    public Image progressBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }


    IEnumerator LoadAsyncOperation()
    {
        //take this scene and load it
        //create an async operation
        //progress bar fill = async operation progress
        //when it's done, load the game--could also prompt user for key press
        //or unlock a button

        //google AsyncOperation for Unity
        //Hard coded scene 2
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(10);
        //check the load
        while (gameLevel.progress < 1)
        {
            //fill bar
            progressBar.fillAmount = gameLevel.progress;
            Debug.Log(gameLevel.progress);
            yield return new WaitForEndOfFrame();
        }
    }
}
