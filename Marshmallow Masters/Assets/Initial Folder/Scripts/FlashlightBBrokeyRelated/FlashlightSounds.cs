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
    public AudioSource audioSourceShake;
    public AudioSource audioSourceClickOn;
    public AudioSource audioSourceClickOff;



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


    public void Awake()
    {
        if (loadAndSave.savedData.toggleOnBGM)
        {
            PlayBGM();



        }
    }


    // Update is called once per frame
    void Update()
    {
        if (loadAndSave.savedData.toggleOnSFX)
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

        
    }

    public void PlayBGM()
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
