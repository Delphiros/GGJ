using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShowText : MonoBehaviour
{
    private Chatbox chatbox;
    private bool isShow = true; //condition something to show
    [SerializeField] private string message;
    
    void Start()
    {
        chatbox = GetComponent<Chatbox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShow && Input.GetKey(KeyCode.D))
        {
            chatbox.ShowMessage(message);
        }
    }
}
