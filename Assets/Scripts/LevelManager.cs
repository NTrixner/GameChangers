using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int currentLevel = 1;
    int totalLevels = 3;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void Awake()
    {
        if(FindObjectsOfType<LevelManager>().Length > 1)
        {
            Destroy(this);
        }
    }

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

    public void LevelDone()
    {
        if (totalLevels < currentLevel)
        {
            currentLevel += 1;
            LoadLevel(currentLevel);
        }
    }
}
