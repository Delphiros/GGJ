using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IInteract
{
    [SerializeField]
    private Animator _animator;

    public void Interact()
    {
        GameManager.Instance.GetTrash();
        // Animation Before Delete

        Destroy(gameObject);
    }

    public void PlayHint()
    {
        _animator.enabled = true;
    }

}
