using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{
    public float rotationSpeed = 45f;
    public bool IsRotationZ = true;


    void Update()
    {
        if (IsRotationZ)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0,Space.Self);
        }
        
        
    }
}
