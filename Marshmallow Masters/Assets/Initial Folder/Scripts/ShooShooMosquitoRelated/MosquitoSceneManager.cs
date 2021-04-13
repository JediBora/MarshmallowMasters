using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MosquitoSceneManager : MonoBehaviour
{

    //The time limit (in seconds)
    public float maxTime;
    //The time (in seconds)
    public float timePassing;

    public GameObject endCanvas;

    public Text shmellowText;



    public string overworldName;

    public LoadAndSave loadAndSave;

    public ShooShooMosquitoGameManger gameManager;

    public MosquitoSpawnerManager mosqManger;


    public FlashlightSounds soundManager;

    // Update is called once per frame
    void Update()
    {

        if (gameManager.timeToSurvive <= 0)
        {
            endCanvas.SetActive(true);

            // TimerFunction();
            if (mosqManger.levelOne)
            {
                shmellowText.text = "+3";

            }
            else if (mosqManger.levelTwo)
            {
                shmellowText.text = "+5";

            }
            else if (mosqManger.levelThree)
            {
                shmellowText.text = "+7";

            }



        }
        else if (gameManager.lives <= 0)
        {
            endCanvas.SetActive(true);

            shmellowText.text = "+0";


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
        loadAndSave.savedData.levelToLoadName = "UpdatedCampOverworld";
        loadAndSave.RewriteSaveFile();

        SceneManager.LoadScene("LoadingScreen");
        //Only use if timer needs to be reset
        //timePassing = 0;
    }
    public void GoBackToCamp()
    {
        soundManager.buttonHasBeenPressed = true;

        loadAndSave.savedData.levelToLoadName = "UpdatedCampOverworld";
        loadAndSave.RewriteSaveFile();
        SceneManager.LoadScene("LoadingScreen");




    }

}
