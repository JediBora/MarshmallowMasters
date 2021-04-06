using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSounds : MonoBehaviour
{

    //Audio to be played
    public AudioClip[] flashlightShake;
    public AudioClip[] flashlightClick;
    public AudioClip[] bGM;

    //Sources to be played
    //This one loops
    public AudioSource audioSourceSFX1;
    //This one doesn't
    public AudioSource audioSourceSFX2;

    //This loops
    public AudioSource audioSourceBGMPlayer;

    //The single audio listener
    public AudioListener audioListener;

    //Scripts to be teasty
    public ShakeDetector shakeDetector;
    public FlashlightDifficultyController difController;

    public bool shakeNoiseChosen;
    public bool flashlightClickPlayed;

    //used to check if bgm or songs are toggled
    public LoadAndSave loadAndSave;

    //Used to identify which games are being played
    public bool flashlightBBrokey;
    public bool marshmallowRoasting;

    public bool bgmIsPlaying;



    // Update is called once per frame
    void Update()
    {
        if (loadAndSave.savedData.toggleOnSFX)
        {
            if (flashlightBBrokey)
                FlashlightBBrokeySounds();
            

        }

        if (loadAndSave.savedData.toggleOnBGM && !bgmIsPlaying)
        {
            if (flashlightBBrokey)
                PlayMarshmallowBGM();


            if (marshmallowRoasting)
                MarshmallowRoastingBGM();


            bgmIsPlaying = true;
        }

    }

    public void MarshmallowRoastingBGM()
    {
        audioSourceBGMPlayer.clip = bGM[3];

        audioSourceBGMPlayer.Play();
    }


    public void FlashlightBBrokeySounds()
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
            audioSourceSFX1.Stop();
        }


    }

    public void PlayMarshmallowBGM()
    {
        if (difController.difficultyOne)
        {
            audioSourceBGMPlayer.clip = bGM[0];
            audioSourceBGMPlayer.Play();
        }
        else if (difController.difficultyTwo)
        {
            audioSourceBGMPlayer.clip = bGM[1];
            audioSourceBGMPlayer.Play();
        }
        else if (difController.difficultyThree)
        {
            audioSourceBGMPlayer.clip = bGM[2];
            audioSourceBGMPlayer.Play();
        }


    }

    void PlayRandomShake()
    {
        if (!shakeNoiseChosen)
        {
            audioSourceSFX1.clip = flashlightShake[Random.Range(0, flashlightShake.Length)];


            audioSourceSFX1.Play();

            shakeNoiseChosen = true;
        }

    }

    void PlayClickOn()
    {
        audioSourceSFX2.clip = flashlightClick[0];
        audioSourceSFX2.Play();

    }

    void PlayClickOff()
    {
        audioSourceSFX2.clip = flashlightClick[1];
        audioSourceSFX2.Play();



    }

}
