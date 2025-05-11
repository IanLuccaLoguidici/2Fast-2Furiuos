using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioClip[] fxs;
    AudioSource AudioS;
    
    void Start()
    {
        AudioS= GetComponent<AudioSource>();
    }

    public void FXSChoque()
    {
      AudioS.clip = fxs[0];
      AudioS.Play();
    }

    public void FXSMusic()
    {
        AudioS.clip = fxs[1];
        AudioS.Play();
    }

    public void FXS_POWER_UP()
    {
        AudioS.clip = fxs[2];
        AudioS.Play();
    }
}
