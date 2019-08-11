using UnityEngine;
using UnityEngine.UI;

public class Disabler : MonoBehaviour
{
    private float disableDuration = 0.0f;

    public delegate void EnableEventHandler();
    public event EnableEventHandler OnEnableEvent;
    public event EnableEventHandler OnDisableEvent;


    private void Update()
    {
        if (disableDuration > 0.0f)
        {
            disableDuration -= Time.deltaTime;

            if (disableDuration <= 0.0f)
            {
                OnEnableEvent();
            }
        }
    }

    public void Disable(float duration)
    {
        disableDuration = duration;
        OnDisableEvent();
    }
}
