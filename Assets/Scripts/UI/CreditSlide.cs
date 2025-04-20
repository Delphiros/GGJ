using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSlide : MonoBehaviour
{
    private void Update()
    {
        transform.position += new Vector3(0f,50f * Time.deltaTime,0f);
    }
}
