using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MosquitoSceneManager : MonoBehaviour
{

    //The time limit (in seconds)
    public float maxTime;
    //The time (in seconds)
    public float timePassing;


    public string overworldName;

    public LoadAndSave loadAndSave;

    public ShooShooMosquitoGameManger gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.timeToSurvive <= 0 || gameManager.lives <= 0)
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
        loadAndSave.savedData.levelToLoadName = "UpdatedCampOverworld";
        loadAndSave.RewriteSaveFile();

        SceneManager.LoadScene("LoadingScreen");
        //Only use if timer needs to be reset
        //timePassing = 0;
    }


}
