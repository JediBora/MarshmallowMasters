using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoSpawnerManager : MonoBehaviour
{

    //Used for setting game difficulty
    public LoadAndSave loadAndSave;

    public bool loadComplete;

    public GameObject upSideSpawner;
    public GameObject downSideSpawner;
    public GameObject leftSideSpawner;
    public GameObject rightSideSpawner;

    public MosquitoSpawner mosquitoSpawnerL;
    public MosquitoSpawner mosquitoSpawnerR;
    public MosquitoSpawner mosquitoSpawnerU;
    public MosquitoSpawner mosquitoSpawnerD;


    public bool leftSideSpawnerActivate;
    public bool rightSideSpawnerActivate;
    public bool upSideSpawnerActivate;
    public bool downSideSpawnerActivate;


    public bool activateMosquitoSpawners = true;


    public float activatedSpawn;

    public bool levelOne;
    public bool levelTwo;
    public bool levelThree;

    //The time limit (in seconds)
    public float spawnActivasionTime;
    //The time (in seconds)
    public float timePassing;
    // Start is called before the first frame update
    void Start()
    {
        mosquitoSpawnerU = upSideSpawner.GetComponent<MosquitoSpawner>();
        mosquitoSpawnerD = downSideSpawner.GetComponent<MosquitoSpawner>();
        mosquitoSpawnerL = leftSideSpawner.GetComponent<MosquitoSpawner>();
        mosquitoSpawnerR = rightSideSpawner.GetComponent<MosquitoSpawner>();


        if (loadAndSave.savedData.setMinigameDifficulty == 1)
        {
            levelOne = true;
            levelTwo = false;
            levelThree = false;
            loadComplete = true;
        }
        else if (loadAndSave.savedData.setMinigameDifficulty == 2)
        {
            levelOne = false;
            levelTwo = true;
            levelThree = false;
            loadComplete = true;
        }
        else if (loadAndSave.savedData.setMinigameDifficulty == 3)
        {
            levelOne = false;
            levelTwo = false;
            levelThree = true;
            loadComplete = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (activateMosquitoSpawners)
        TimerFunction();



    }

    void TimerFunction()
    {
        timePassing += Time.deltaTime;

        if (timePassing >= spawnActivasionTime)
        {
            timerEnded();
        }
    }
    void timerEnded()
    {
        int spawnerActivasionLevelTwo = 0;


        activatedSpawn = (Random.Range(1,4));

        //Allows for spawning in two places
        if (levelTwo)
        {
            spawnerActivasionLevelTwo = (Random.Range(1, 4));


        }

        if (activatedSpawn == 1 || spawnerActivasionLevelTwo == 1)
        {
            mosquitoSpawnerU.StartCoroutine("SpawnFlyUpSideSpawner");
        }
        if (activatedSpawn == 2 || spawnerActivasionLevelTwo == 2)
        {
            mosquitoSpawnerD.StartCoroutine("SpawnFlyDownSideSpawner");
        }
        if (activatedSpawn == 3 || spawnerActivasionLevelTwo == 3)
        {
            mosquitoSpawnerL.StartCoroutine("SpawnFlyLeftSideSpawner");
        }
        if (activatedSpawn == 4 || spawnerActivasionLevelTwo == 4)
        {
            mosquitoSpawnerR.StartCoroutine("SpawnFlyRightSideSpawner");
        }

        //Allows for spawning in two places
        if (levelThree)
        {
            spawnerActivasionLevelTwo = (Random.Range(1, 4));


        }

        if (activatedSpawn == 1 || spawnerActivasionLevelTwo == 1)
        {
            mosquitoSpawnerU.StartCoroutine("SpawnFlyUpSideSpawner");
        }
        if (activatedSpawn == 2 || spawnerActivasionLevelTwo == 2)
        {
            mosquitoSpawnerD.StartCoroutine("SpawnFlyDownSideSpawner");
        }
        if (activatedSpawn == 3 || spawnerActivasionLevelTwo == 3)
        {
            mosquitoSpawnerL.StartCoroutine("SpawnFlyLeftSideSpawner");
        }
        if (activatedSpawn == 4 || spawnerActivasionLevelTwo == 4)
        {
            mosquitoSpawnerR.StartCoroutine("SpawnFlyRightSideSpawner");
        }


        //Only use if timer needs to be reset
        timePassing = 0;
    }

}
