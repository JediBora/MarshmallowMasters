using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashlightScenemanager : MonoBehaviour
{

    public GameController gameController;

    public string overworldName;

    public LoadAndSave loadAndSave;


    //The time limit (in seconds)
    public float maxTime;
    //The time (in seconds)
    public float timePassing;



    void TimerFunction()
    {
        timePassing += Time.deltaTime;

        if (timePassing >= maxTime)
        {
            timerEnded();
        }
    }
    void timerEnded()
    {
        //Do your stuff here.
        loadAndSave.savedData.levelToLoadName = "UpdatedCampOverworld";
        loadAndSave.RewriteSaveFile();
        SceneManager.LoadScene("LoadingScreen");

    }

    public void GoBackToCamp()
    {
        loadAndSave.savedData.levelToLoadName = "UpdatedCampOverworld";
        loadAndSave.RewriteSaveFile();
        SceneManager.LoadScene("LoadingScreen");




    }
}
