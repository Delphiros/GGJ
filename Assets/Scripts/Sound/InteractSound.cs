using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSound : MonoBehaviour,IInteract
{
    [SerializeField] private SoundName sound;

    public void Interact()
    {
        SoundManager.instance.Play(sound);
        Debug.Log("Play Sound");
    }
 
}
