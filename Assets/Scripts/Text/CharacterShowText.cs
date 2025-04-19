using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShowText : MonoBehaviour, IInteract
{
    private CharacterChatBox chatbox;
    [SerializeField] private string[] message;
    [SerializeField] private string[] endMessage;
    public int messageIndex;
    
    
    
    void Start()
    {
        chatbox = GetComponent<CharacterChatBox>();
    }

    private void Update()
    {
        if (GameManager.Instance.IsChangeColor)
        {
            message = null;
            message = endMessage;
        }
    }

    public void Interact()
    {
        Debug.Log("interact");
        if (messageIndex < message.Length)
        {
            chatbox.Say(message[messageIndex]);
            messageIndex++;
        }
        else
        {
            Debug.Log("index reset");
            messageIndex = 0;
        }
    }
}
