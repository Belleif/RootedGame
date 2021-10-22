using System.Collections;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour
{
    public GameObject loadingScreenObj;
    public Slider theslider;

    AsyncOperation async;

    public void LoadScreenExample()
    {
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(0);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            theslider.value = async.progress;
            if (async.progress == 0.9f)
            {
                theslider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        
        }
    }
}