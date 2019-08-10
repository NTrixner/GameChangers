using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatPlayer : MonoBehaviour
{

    [SerializeField]
    private PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }
        transform.LookAt(player.transform, Vector3.up);
        float rotY = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(new Vector3(0, rotY, 0));
    }
}
