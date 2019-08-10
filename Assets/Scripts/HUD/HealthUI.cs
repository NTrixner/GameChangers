using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    Image empty;

    [SerializeField]
    Image full;

    public bool isFull
    {
        get;
        private set;
    }

    private void Awake()
    {
        isFull = true;
    }
    public void SetEmpty()
    {
        full.gameObject.SetActive(false);
        empty.gameObject.SetActive(true);
        isFull = false;
    }

    public void SetFull()
    {

        full.gameObject.SetActive(true);
        empty.gameObject.SetActive(false);
        isFull = true;
    }

}
