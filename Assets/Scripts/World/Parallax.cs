using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startPos;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startPos = transform.position.x;
    }

    private void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect; // 0 = Move with Camera || 1 = won't Move || 0.5 = Half

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }

}
