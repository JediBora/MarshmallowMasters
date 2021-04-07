using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSFXCanvas : MonoBehaviour
{
    public GameObject sFXBGMCanvas;
    public LoadAndSave loadAndSave;

    public GameObject soundOnOff;
    public GameObject musicOnOff;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void HideUnhideUI()
    {
        if (sFXBGMCanvas.activeInHierarchy)
            sFXBGMCanvas.SetActive(false);
        else if (!sFXBGMCanvas.activeInHierarchy)
            sFXBGMCanvas.SetActive(true);
    }

    public void ToggleSound()
    {
        if (loadAndSave.savedData.toggleOnSFX)
        {
            loadAndSave.savedData.toggleOnSFX = false;



        }
        else if (!loadAndSave.savedData.toggleOnSFX)
        {
            loadAndSave.savedData.toggleOnSFX = true;



        }


    }

    public void UpdateUI()
    {
        if (loadAndSave.savedData.toggleOnSFX)
            soundOnOff.SetActive(true);
        else if (!loadAndSave.savedData.toggleOnSFX)
            soundOnOff.SetActive(false);

        if (loadAndSave.savedData.toggleOnBGM)
            musicOnOff.SetActive(true);
        else if (!loadAndSave.savedData.toggleOnBGM)
            musicOnOff.SetActive(false);

    }


    public void ToggleMusic()
    {
        if (musicOnOff.activeInHierarchy && loadAndSave.savedData.toggleOnBGM)
        {
            loadAndSave.savedData.toggleOnBGM = false;



        }
        else if (!musicOnOff.activeInHierarchy && !loadAndSave.savedData.toggleOnBGM)
        {
            loadAndSave.savedData.toggleOnBGM = true;



        }


    }

}
