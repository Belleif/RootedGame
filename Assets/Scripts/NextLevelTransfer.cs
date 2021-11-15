using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTransfer : MonoBehaviour
{
    public int levelChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int levelBeat = SceneManager.GetActiveScene().buildIndex;
        if (levelBeat == 3)
        {
            MainMenu.oneComplete = 1;
            PlayerPrefs.SetInt("OneDone", MainMenu.oneComplete);
            Debug.Log("Level One Done");
        }
        if (levelBeat == 4)
        {
            MainMenu.twoComplete = 1;
            PlayerPrefs.SetInt("TwoDone", MainMenu.twoComplete);
            Debug.Log("Level Two Done");
        }
        if (levelBeat == 5)
        {
            MainMenu.threeComplete = 1;
            PlayerPrefs.SetInt("ThreeDone", MainMenu.threeComplete);
            Debug.Log("Level Three Done");
        }
        if (levelBeat == 6)
        {
            MainMenu.fourComplete = 1;
            PlayerPrefs.SetInt("FourDone", MainMenu.fourComplete);
        }
        if (levelBeat == 7)
        {
            MainMenu.fiveComplete = 1;
            PlayerPrefs.SetInt("FiveDone", MainMenu.fiveComplete);
        }
        if (levelBeat == 8)
        {
            MainMenu.sixComplete = 1;
            PlayerPrefs.SetInt("SixDone", MainMenu.sixComplete);
        }
        if (levelBeat == 7)
        {
            MainMenu.sevenComplete = 1;
            PlayerPrefs.SetInt("SevenDone", MainMenu.sevenComplete);
        }
        if (levelBeat == 8)
        {
            MainMenu.eightComplete = 1;
            PlayerPrefs.SetInt("EightDone", MainMenu.eightComplete);
        }
        SceneManager.LoadScene(levelChange);
        
    }
}
