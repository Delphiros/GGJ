using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorSprite : MonoBehaviour
{
    private SpriteRenderer _renderer;
    [SerializeField] private Sprite spriteColor;
    [SerializeField] private Sprite spriteUnColor;
    
    
    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        ChangeColor(false);
    }

    private void Update()
    {
        if (GameManager.Instance.IsChangeColor)
        {
            ChangeColor(true);
        }
        else
        {
            ChangeColor(false);
        }
    }

    public void ChangeColor(bool IsColor)
    {
        if (IsColor)
        {
            _renderer.sprite = spriteColor;
        }
        else
        {
            _renderer.sprite = spriteUnColor;
        }

    }
    
    

}
