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
        if (levelBeat == 1)
        {
            MainMenu.oneComplete = 1;
            PlayerPrefs.SetInt("OneDone", MainMenu.oneComplete);
        }
        if (levelBeat == 2)
        {
            MainMenu.twoComplete = 1;
            PlayerPrefs.SetInt("TwoDone", MainMenu.twoComplete);
        }
        if (levelBeat == 3)
        {
            MainMenu.threeComplete = 1;
            PlayerPrefs.SetInt("ThreeDone", MainMenu.threeComplete);
        }
        if (levelBeat == 4)
        {
            MainMenu.fourComplete = 1;
            PlayerPrefs.SetInt("FourDone", MainMenu.fourComplete);
        }
        if (levelBeat == 5)
        {
            MainMenu.fiveComplete = 1;
            PlayerPrefs.SetInt("FiveDone", MainMenu.fiveComplete);
        }
        if (levelBeat == 6)
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
