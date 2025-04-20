using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSound : MonoBehaviour,IInteract
{
    [SerializeField] private SoundName sound;

    void Start()
    {
        throw new NotImplementedException();
    }

    public void Interact()
    {
        SoundManager.instance.Play(sound);
        Debug.Log("Play Sound");
    }
 
}
