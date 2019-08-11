using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Disabler))]
public class VignetteDisplayer : MonoBehaviour
{
    Disabler disabler;

    [SerializeField]
    private Image vignette;


    private enum ImageState
    {
        HIDDEN, SHOWN, FADEIN, FADEOUT
    }

    private ImageState state = ImageState.HIDDEN;

    private float counter;
    private float target = 0.5f;

    private void Awake()
    {
        disabler = GetComponent<Disabler>();
        disabler.OnDisableEvent += ShowVignette;
        disabler.OnEnableEvent += HideVignette;
    }

    void ShowVignette()
    {
        counter = 0;
        state = ImageState.FADEIN;
    }

    void HideVignette()
    {
        counter = 0;
        state = ImageState.FADEOUT;
    }

    private void Update()
    {
        if(state == ImageState.FADEIN || state == ImageState.FADEOUT)
        {
            Color c = vignette.color;
            counter += Time.deltaTime;
            if(counter >= target)
            {
                if(state == ImageState.FADEIN)
                {
                    c.a = 1;
                    state = ImageState.SHOWN;
                }
                else if(state == ImageState.FADEOUT)
                {
                    c.a = 0;
                    state = ImageState.HIDDEN;
                }
            }
            else
            {
                if (state == ImageState.FADEIN)
                {
                    c.a += (counter / target);
                }
                else
                {
                    c.a -= (counter / target);
                }

            }
            vignette.color = c;
        }
    }

}
