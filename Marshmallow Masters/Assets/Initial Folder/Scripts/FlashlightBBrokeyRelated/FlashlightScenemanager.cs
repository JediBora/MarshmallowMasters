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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.wentInsane || gameController.outOfForest)
        {
            TimerFunction();
           

        }
    }


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
        loadAndSave.savedData.levelToLoadName = "CampOverworld";
        loadAndSave.RewriteSaveFile();
        SceneManager.LoadScene("LoadingScreen");
        //Only use if timer needs to be reset
        //timePassing = 0;
    }
}
