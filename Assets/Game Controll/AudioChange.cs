using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChange : MonoBehaviour
{
    public AudioClip[] AC;
    public void NightSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = AC[1];
        audio.volume = 1;
        audio.Play();
        if (GM.Mute)
            audio.Stop();
    }
    public void DaySound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = AC[0];
        audio.volume = 0.1f;
        audio.Play();
        if (GM.Mute)
            audio.Stop();
    }

}
