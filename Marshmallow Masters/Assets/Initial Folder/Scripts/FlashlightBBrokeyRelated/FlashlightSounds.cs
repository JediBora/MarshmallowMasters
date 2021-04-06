using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSounds : MonoBehaviour
{

    //Audio to be played
    [Header("Flashlight Sounds")]
    public AudioClip[] flashlightShake;
    public AudioClip[] flashlightClick;

    [Header("Modquito Sounds")]
    public AudioClip[] flySwatted;
    public AudioClip[] flyBite;

    [Header("BGM")]
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
    public bool shooShooMosquito;
    public bool saveYourSandwich;
    public bool canoeBooBoo;
    public bool FishingFishers;


    public bool bgmIsPlaying;

    //Mosquito Specific
    public bool mosquitoDeathSound;
    public bool mosquitoBiteSound;

    // Update is called once per frame
    void Update()
    {
        if (loadAndSave.savedData.toggleOnSFX)
        {
            if (flashlightBBrokey)
                FlashlightBBrokeySounds();

            if (shooShooMosquito)
                ShooShooMosquitoSounds();
        }

        if (loadAndSave.savedData.toggleOnBGM && !bgmIsPlaying)
        {
            if (flashlightBBrokey)
                PlayMarshmallowBGM();


            if (marshmallowRoasting)
                MarshmallowRoastingBGM();

            if (shooShooMosquito)
                ShooShooMosquitoBGM();

            if (saveYourSandwich)
                SaveYourSandwich();

            if (canoeBooBoo)
                CanoeBooBooBGM();

            if (FishingFishers)
                FishingFishersBGM();

            bgmIsPlaying = true;
        }

    }

    public void FishingFishersBGM()
    {
        audioSourceBGMPlayer.clip = bGM[7];

        audioSourceBGMPlayer.Play();

    }


    public void CanoeBooBooBGM()
    {
        audioSourceBGMPlayer.clip = bGM[6];

        audioSourceBGMPlayer.Play();
    }

    public void SaveYourSandwich()
    {
        audioSourceBGMPlayer.clip = bGM[5];

        audioSourceBGMPlayer.Play();

    }

    public void ShooShooMosquitoBGM()
    {
        audioSourceBGMPlayer.clip = bGM[4];

        audioSourceBGMPlayer.Play();

    }

    public void MarshmallowRoastingBGM()
    {
        audioSourceBGMPlayer.clip = bGM[3];

        audioSourceBGMPlayer.Play();
    }

    public void ShooShooMosquitoSounds()
    {

        if (mosquitoDeathSound)
            StartCoroutine("ShooShooMosquitoDeathSounds");

            


        if (mosquitoBiteSound)
            StartCoroutine("ShooShooMosquitoBiteSounds");
        

    }

    IEnumerator ShooShooMosquitoDeathSounds()
    {

        Debug.Log("make sound plz");

        audioSourceSFX2.clip = flySwatted[Random.Range(0, flySwatted.Length)];


        audioSourceSFX2.Play();


        mosquitoDeathSound = false;

        yield return null;
    }

    IEnumerator ShooShooMosquitoBiteSounds()
    {
        Debug.Log("make sound plz 2");

        audioSourceSFX2.clip = flyBite[Random.Range(0, flyBite.Length)];


        audioSourceSFX2.Play();


        mosquitoBiteSound = false;
        yield return null;
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
