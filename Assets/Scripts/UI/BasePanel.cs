using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    public virtual void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public virtual void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}