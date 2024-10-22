using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Sounds
{
    BACKGROUND,
    BUTTONCLICK,
    STONECOLLECT,
    HIT,
    GAMEOVER,
    LevelCOMPLETE
}
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance{get{return instance;}}
    public AudioSource backgroundMusic;
    public AudioSource soundEffect;
    public SoundType[] sounds;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayBackgroundMusic(Sounds.BACKGROUND);
    }

    public void PlayBackgroundMusic(Sounds sound)
    {
        AudioClip audioClip = GetAudioClip(sound);
        backgroundMusic.clip = audioClip;
        backgroundMusic.Play();
    }

    public void PlaySoundEffect(Sounds sound)
    {
        AudioClip audioClip = GetAudioClip(sound);
        soundEffect.PlayOneShot(audioClip);
    }


    private AudioClip GetAudioClip(Sounds sound)
    {
        SoundType item = Array.Find(sounds,i => i.soundType == sound);
        if(item != null)
        {
            return item.audioClip;
        }
        return null;
    }
}
