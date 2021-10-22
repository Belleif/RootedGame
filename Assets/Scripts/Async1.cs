using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Async1 : MonoBehaviour
{
    //public string nameOfLevel;
    private IEnumerator coroutine;
    public void LoadLevel(int buildIndex)
 	{
		coroutine = LoadYourAsyncScene(buildIndex);
        StartCoroutine(coroutine);
	}
	
	IEnumerator LoadYourAsyncScene(int buildIndex)
	{
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildIndex);

        while(!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress);
			
            Debug.Log(progress);

            yield return null;
       	}
    }
}