using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObject : PoolingBase
{
    [Header("사운드 관련")]
    [SerializeField] private AudioSource audio;
    public void StartAudio(AudioClip _clip, AudioSource _audio)
    {
        audio.volume = _audio.volume;
        audio.clip = _clip;
        audio.Play();
        StartCoroutine(Pool());
    }
}
