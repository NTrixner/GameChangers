using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bleeps : MonoBehaviour
{
    [SerializeField]
    private Sprite[] bleeps;

    [SerializeField]
    private Image target;

    private void Awake()
    {
        target.sprite = bleeps[Random.Range(0, bleeps.Length)];
    }

}
