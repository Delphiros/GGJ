using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SoundName
{
    
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    public static event Action<string> OnPlaySFXEvent;
    public static event Action<string, bool> OnPlayBGMEvent;
    public static event Action OnStopMusicEvent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAudioClips();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadAudioClips()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio");
        foreach (AudioClip clip in clips)
        {
            audioClips.Add(clip.name, clip);
        }
    }

    public static void PlaySFX(string clipName)
    {
        OnPlaySFXEvent?.Invoke(clipName);
    }

    public static void PlayBGM(string clipName, bool loop = true)
    {
        OnPlayBGMEvent?.Invoke(clipName,loop);
    }

    public static void StopMusic()
    {
        OnStopMusicEvent?.Invoke();
    }

    void HandleSFX(string clipName)
    {
        
    }

    private void OnEnable()
    {
        
    }
}
