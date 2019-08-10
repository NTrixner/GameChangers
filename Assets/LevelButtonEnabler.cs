using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonEnabler : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private LevelManager levelManager;

    [SerializeField]
    private int level;

    private void Awake()
    {
        button.interactable = levelManager.HasLevel(level - 1);
    }

}
