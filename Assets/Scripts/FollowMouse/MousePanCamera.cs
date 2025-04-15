using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MousePanCamera : MonoBehaviour
{
    [Header("Panning Setting")]
    [Range(0f, 0.5f)] public float edgeTriggerThreshold = 0.05f;
    [SerializeField] private float panSpeed = 5f;
    [SerializeField] private float panLimit = 5f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.mousePosition.x / Screen.width;
        float panOffset = 0f;
        
        if (mouseX < edgeTriggerThreshold) //
        {
            panOffset = Mathf.Lerp(panOffset, -1f, (edgeTriggerThreshold - mouseX) / edgeTriggerThreshold);
        }
        else if (mouseX > 1f - edgeTriggerThreshold)
        {
            panOffset = Mathf.Lerp(panOffset, 1f, (mouseX - (1f - edgeTriggerThreshold)) / edgeTriggerThreshold);
        }
        else
        {
            panOffset = Mathf.Lerp(panOffset, 0f, Time.deltaTime * panSpeed);
        }

        targetPosition = initialPosition + Vector3.right * panOffset * panLimit;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * panSpeed);
    }
}
