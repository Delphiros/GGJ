using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IInteract
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

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
