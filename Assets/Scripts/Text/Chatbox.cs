using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Chatbox : MonoBehaviour
{
    public GameObject chatboxPrefab;
    public Vector3 chatboxOffset = new Vector3(0f,2f,0f);

    private GameObject currentChatbox;
    private TextMeshProUGUI chatBoxText;

    public void ShowMessage(string message)
    {
        if (chatboxPrefab != null)
        {
            Destroy(currentChatbox);
        }

        currentChatbox = Instantiate(chatboxPrefab, transform.position + chatboxOffset, quaternion.identity);
        currentChatbox.transform.SetParent(FindObjectOfType<Canvas>().transform,false);

        chatBoxText = currentChatbox.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(chatBoxText.name);
        if (chatBoxText != null)
        {
            chatBoxText.text = message;
        }
        else
        {
            Debug.Log("chatbox null");
        }
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
