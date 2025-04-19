using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            SoundManager.instance.Play(SoundName.handpanSFX);
        }

        if (Input.GetKey(KeyCode.W))
        {
            SoundManager.instance.Play(SoundName.handpanBGM);

        }
        if (Input.GetKey(KeyCode.E))
        {
            SoundManager.instance.Play(SoundName.wind);

        }
        if (Input.GetKey(KeyCode.R))
        {
            SoundManager.instance.Play(SoundName.bird);

        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SoundManager.instance.Play(SoundName.click);

        }
    }
}
