using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWhite : MonoBehaviour
{
    
    public void FadeChangeColor()
    {
        GameManager.Instance.IsChangeColor = true;
    }

    public void SlideUpCredit()
    {
        GameManager.Instance._credit.SetActive(true);
    }
}
