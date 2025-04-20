using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IInteract
{
    [SerializeField]
    private Animator _animator;
    private CheckTrash him;

    public void Start()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    public void InputStart(CheckTrash trash)
    {
        him = trash;
    }

    public void Interact()
    {
        GameManager.Instance.GetTrash(SoundName.Wink,him);
        // Animation Before Delete

        Destroy(gameObject, 0.1f);
    }

    public void PlayHint()
    {
        _animator.enabled = true;
    }

}
