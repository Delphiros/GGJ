using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IInteract
{

    public void Interact()
    {
        GameManager.Instance.GetTrash();
        // Animation Before Delete

        Destroy(gameObject);
    }

}
