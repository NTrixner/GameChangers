using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour { 

    static int currentLevel = 1;
    static int totalLevels = 3;

    static string ProgressKey = "level_progress";

    public void LevelComplete(int levelNumber)
    {
        PlayerPrefs.SetInt(ProgressKey, levelNumber);
        PlayerPrefs.Save();
    }

    public void LoadLevel(int levelNumber)
    {
        currentLevel = levelNumber;
        SceneManager.LoadScene(levelNumber + 3);
    }

    public bool HasLevel(int levelNumber)
    {
        int levelgotten = PlayerPrefs.GetInt(ProgressKey, 0);

        return levelNumber <= levelgotten;
    }

    public void ShowDeathScreen()
    {
        currentLevel = 1;
        SceneManager.LoadScene(1);
    }

    public void ShowSuccessScreen()
    {
        if(currentLevel == 3)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            LevelComplete(currentLevel);
            SceneManager.LoadScene(2);
        }
    }
    
    public void ReloadLevel()
    {
        LoadLevel(currentLevel);
    }

    public void ShowMainMenu()
    {
        currentLevel = 1;
        SceneManager.LoadScene(0);
    }

    public void LevelDone()
    {
        if (currentLevel < totalLevels)
        {
            currentLevel += 1;
            LoadLevel(currentLevel);
        }
    }
}
