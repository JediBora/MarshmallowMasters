using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSounds : MonoBehaviour
{
    public AudioClip[] flashlightShake;
    public AudioClip[] flashlightClick;

    public AudioSource audioSourceShake;
    public AudioSource audioSourceClickOn;
    public AudioSource audioSourceClickOff;


    public AudioSource bGM;
    public AudioListener audioListener;

    public ShakeDetector shakeDetector;

    public bool shakeNoiseChosen;
    public bool flashlightClickPlayed;


    // Update is called once per frame
    void Update()
    {
        if (shakeDetector.deviceIsShaking)
        {
            PlayRandomShake();

            if (flashlightClickPlayed)
            {
                PlayClickOff();
                flashlightClickPlayed = false;

            }


            

        }
        else if (!shakeDetector.deviceIsShaking)
        {
            if (!flashlightClickPlayed)
            {
                PlayClickOn();
                flashlightClickPlayed = true;
            }
                shakeNoiseChosen = false;
            audioSourceShake.Stop();
        }
    }


    void PlayRandomShake()
    {
        if (!shakeNoiseChosen)
        {
            audioSourceShake.clip = flashlightShake[Random.Range(0, flashlightShake.Length)];


            audioSourceShake.Play();

            shakeNoiseChosen = true;
        }
            
    }

    void PlayClickOn()
    {
        audioSourceClickOn.clip = flashlightClick[0];
        audioSourceClickOn.Play();

    }

    void PlayClickOff()
    {
        audioSourceClickOff.clip = flashlightClick[1];
        audioSourceClickOff.Play();



    }

}
