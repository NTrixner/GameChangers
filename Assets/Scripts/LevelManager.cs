using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour { 

    static int currentLevel = 1;
    static int totalLevels = 3;

    public void LevelComplete(int levelNumber)
    {
        PlayerPrefs.SetInt("Level", levelNumber);
    }

    public void LoadLevel(int levelNumber)
    {
        currentLevel = levelNumber;
        SceneManager.LoadScene(levelNumber + 2);
    }

    public bool HasLevel(int levelNumber)
    {
        int levelgotten = PlayerPrefs.GetInt("Level", 0);

        return levelNumber <= levelgotten;
    }

    public void ShowDeathScreen()
    {
        currentLevel = 1;
        SceneManager.LoadScene(1);
    }

    public void ShowSuccessScreen()
    {
        SceneManager.LoadScene(2);
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
