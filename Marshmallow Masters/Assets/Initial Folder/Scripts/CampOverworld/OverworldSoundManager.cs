using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldSoundManager : MonoBehaviour
{

    public AudioClip bGMClip;
    public AudioSource bGMPlayer;
    public AudioListener audioListener;

    public LoadAndSave loadAndSave;

    public bool clipFinished;

    // Update is called once per frame
    void Update()
    {
        if (loadAndSave.savedData.toggleOnSFX && !clipFinished)
        {
            bGMPlayer.clip = bGMClip;

            bGMPlayer.Play();
            clipFinished = true;
        }
    }
}
