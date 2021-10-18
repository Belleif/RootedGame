using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int sceneToLoad;
    private AsyncOperation loadingOperation;
    private float loadProgress;
    public Slider progressBar;
    public Text percentLoaded;
    private float progressValue;
    // Start is called before the first frame update
    void Start()
    {
        loadProgress = loadingOperation.progress;
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        percentLoaded.text = Mathf.Round(progressValue * 100) + "%";
        if(loadingOperation.isDone)
        {
            Debug.Log("Loading has finished.");
        }
    }
}
