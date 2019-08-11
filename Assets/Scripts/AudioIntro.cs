using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioIntro : MonoBehaviour
{
    // Play an intro Clip followed by a loop
    [SerializeField]
    private AudioSource introAudioSource;
    [SerializeField]
    private AudioSource loopAudioSource;

    void Start()
    {
        double introDuration = (double)introAudioSource.clip.samples / introAudioSource.clip.frequency;
        double startTime = AudioSettings.dspTime;
        introAudioSource.PlayScheduled(startTime);
        loopAudioSource.PlayScheduled(startTime + introDuration);
    }
}
