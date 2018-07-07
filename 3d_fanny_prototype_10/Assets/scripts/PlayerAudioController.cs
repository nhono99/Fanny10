using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAudioController{

    [SerializeField]
    AudioSource audSrc;
    [SerializeField]
    AudioClip tapClip;
    [SerializeField]
    AudioClip deadClip;

    public void PlayTap()
    {
        audSrc.PlayOneShot(tapClip);
    }
    public void PlayDead()
    {
        audSrc.PlayOneShot(deadClip);
    }
}
