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
            SoundManager.instance.Play(SoundManager.SoundName.handpanSFX);
        }

        if (Input.GetKey(KeyCode.W))
        {
            SoundManager.instance.Play(SoundManager.SoundName.handpanBGM);

        }
    }
}
