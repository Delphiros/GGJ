using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShowText : MonoBehaviour, IInteract
{
    private CharacterChatBox chatbox;
    [SerializeField] private string[] message;
    public int messageIndex;
    
    void Start()
    {
        chatbox = GetComponent<CharacterChatBox>();
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
