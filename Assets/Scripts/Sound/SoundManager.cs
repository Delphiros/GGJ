using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundName
{
    handpanBGM,
    handpanSFX,
    button,
    click,
    wind,
    bird,
    bush,
    MetalTrash,
    PlasticTrash,
    Stone1,
    Stone2,
    Toy1,
    Toy2,
    Water,
    Tree,
    TrashMoneyPaper,
    PotionBubble,
    Battery,
    Bone,
    Wheel,
    Guitar,
    Wink,
}

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Sound[] _sounds;

    
    private static SoundManager _instance;
    public static SoundManager instance => _instance;
    

    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;

        foreach (Sound sound in _sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.loop;
            
        }
        
        _instance = this;
        
        
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        
    }


    public void Play(SoundName name)
    {

        Sound sound = GetSound(name);
        
        if (sound.audioSource == null)
        {
            Debug.LogError("Sound :" + name);
            return;
        }
        
        sound.audioSource.Play();
    }
    
    

    private Sound GetSound(SoundName name)
    {
        return Array.Find(_sounds, s => s.soundName == name);
    }



    public void Stop(SoundName name)
    {
        Sound sound = GetSound(name);

        if (sound.audioSource == null)
        {
            Debug.LogError("Sound :" + name);
            return;
        }

        sound.audioSource.Stop();
    }
}

[Serializable]public class Sound
{
    [SerializeField] private SoundName _soundName;
    public SoundName soundName => _soundName;

    public enum SoundType
    {
        BackgroundMusic,
        SoundFX,
    }

    public SoundType soundType;

    [SerializeField] private AudioClip _clip;
    public AudioClip clip => _clip;

    [Range(0f, 1f)]
    [SerializeField] private float _volume = 1f;
    public float volume => _volume;

    [SerializeField] private bool _loop;
    public bool loop => _loop;
    
    [HideInInspector]
    public AudioSource audioSource;
}