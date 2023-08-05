using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] 
    private AudioMixer _masterMixer;

    [SerializeField] 
    private AudioSource _bgmSource;

    [SerializeField] 
    private AudioSource _sfxSource;
    
    [SerializeField]
    private AudioClip _bgmClip;

    private void Awake()
    {
        SetBGM();
    }

    public void SetBGM()
    {
        _bgmSource.clip = _bgmClip;
        _bgmSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }
}
