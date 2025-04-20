using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;


public class CharacterChatBox : MonoBehaviour
{
    [SerializeField] private GameObject chatboxPrefabs;
    public float displayDuration = 5f;

    [SerializeField]private Vector3 chatboxOffset = new Vector3(0f, 2f, 0f);
    public float LookAtCameraSpeed = 5f;

    private Queue<string> messageQueue = new Queue<string>();
    private GameObject currentChatbox;
    private TMP_Text chatboxText;

    private Camera mainCamera;
    public bool isShowingMessage;
    private Coroutine showMessageCoroutine;
    private bool skipToNext = false;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    //Call Text
    public void Say(string message)
    {
        messageQueue.Enqueue(message);
        if (!isShowingMessage && messageQueue.Count > 0)
        {
            showMessageCoroutine = StartCoroutine(ShowMessageSequence());
        }
    }

    private void Update()
    {
        if (isShowingMessage && Input.GetMouseButtonDown(0))
        {
            skipToNext = true;
        }
    }


    /*public void GoToNextMessage()
    {
        if (isShowingMessage && messageQueue.Count > 0)
        {
            StopCoroutine(ShowMessageSequence());
            showMessageCoroutine = StartCoroutine(ShowMessageSequence());
            
        }
        else if (isShowingMessage && messageQueue.Count == 0 && currentChatbox != null)
        {
            isShowingMessage = false;
            Destroy(currentChatbox);
            currentChatbox = null;
            chatboxText = null;
        }
    }*/
    
    //ShowText
    IEnumerator ShowMessageSequence()
    {
        isShowingMessage = true;
        
        if (currentChatbox == null && chatboxPrefabs != null)
        {
            currentChatbox = Instantiate(chatboxPrefabs, transform.position + chatboxOffset, quaternion.identity);
            chatboxText = currentChatbox.GetComponentInChildren<TMP_Text>();
            if (chatboxText == null)
            {
                Debug.Log("ShowMessageSequence chatboxtext NULL");
            }
        }
        
        
        while (messageQueue.Count > 0 && chatboxText != null)
        {
            string messageShow = messageQueue.Dequeue();
            chatboxText.text = messageShow;
            skipToNext = false;
            
            float timer = 0f;

            while (timer < displayDuration && !skipToNext)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            skipToNext = false;
            /*yield return ShowSingleMessage(messageShow);
            yield return new WaitForSeconds(displayDuration);
            Destroy(currentChatbox);
            currentChatbox = null;*/
        }
        
        isShowingMessage = false;
        if (currentChatbox != null)
        {
            Destroy(currentChatbox);
            currentChatbox = null;
            chatboxText = null;
        }

    }

    /*IEnumerator ShowSingleMessage(string message)
    {
        if (chatboxPrefabs != null)
        {
            currentChatbox = Instantiate(chatboxPrefabs, this.transform.position + chatboxOffset, Quaternion.identity);
            chatboxText = currentChatbox.GetComponentInChildren<TMP_Text>();
            
            if (chatboxText != null)
            {
                chatboxText.text = message;
            }
            else
            {
                Debug.Log("ChatboxText NUll");
            }

            yield return null;
        }
        else
        {
            Debug.Log("Prefabs Chatbox null");
        }
    }*/

    //LookAtCamera
    private void LateUpdate()
    {
        if (currentChatbox != null && mainCamera != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(currentChatbox.transform.position - mainCamera.transform.position);
            currentChatbox.transform.rotation = Quaternion.Slerp(currentChatbox.transform.rotation, targetRotation,
                Time.deltaTime * LookAtCameraSpeed);
        }
    }
}
