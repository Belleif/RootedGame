using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene(5);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(6);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(7);
    }

    public void LevelGrandmas()
    {
        SceneManager.LoadScene(8);
    }

    public void LevelBoss()
    {
        SceneManager.LoadScene(9);
    }

    public void TestLevelOne()
    {
        SceneManager.LoadScene(10);
    }

    public void TestLevelTwo()
    {
        SceneManager.LoadScene(11);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }




}
