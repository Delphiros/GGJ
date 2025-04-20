using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrash : MonoBehaviour
{
    private Trash _trash;

    private void Awake()
    {
        _trash = GetComponentInChildren<Trash>();    
    }

    public void PlayHint()
    {
        _trash.PlayHint();
    }
}
