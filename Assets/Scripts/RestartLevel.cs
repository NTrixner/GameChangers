using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    [SerializeField]
    LevelManager levelManager;

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            levelManager.ReloadLevel();
        }
    }
}
