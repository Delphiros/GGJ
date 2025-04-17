using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]private Transform mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera != null)
        {
            mainCamera = Camera.main.transform;
        }
        else
        {
            Debug.Log("main camera lost");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (mainCamera != null)
        {
            Vector3 directionToCamera = mainCamera.position - transform.position;
            directionToCamera.z = 0f;
            
            if (directionToCamera != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera);

                transform.rotation = targetRotation;
            }

        }
    }
}
