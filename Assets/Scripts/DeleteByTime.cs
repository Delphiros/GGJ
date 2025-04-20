using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteByTime : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject,2f);
    }
}
