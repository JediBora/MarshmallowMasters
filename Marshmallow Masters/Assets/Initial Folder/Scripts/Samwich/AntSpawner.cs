using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AntSpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public GameObject ant;
    public float antSpeed = 5;
    public float antSpeedMax = 25;
    public float timerEnd = 3;
    //based on the speed of the ant it will increase spawning by lowering the timerEnd
    public int antSpawnIncreaseTime;
    public float spawnTimeIncrease= 0.1f;
    float time = 0;

    public float lives = 3;
    float gameTime;

   

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //this will spawn an ant and increase the spawned ants speed if their speed doesn't pass the set max speed.
        if (time >= timerEnd)
        {
            SpawnAnt();
            time = 0;
            if (antSpeed < antSpeedMax)
            {
                antSpeed++;
            }
            if (antSpawnIncreaseTime <= antSpeed & timerEnd > 0.5)
            {
                timerEnd = timerEnd - spawnTimeIncrease;
                

            }
            if (timerEnd <= 0.5)
            {
                timerEnd = 0.5f;
            }
          
        }

        // once the lives run out load scene zero
        if (lives <= 0)
        {
            SceneManager.LoadScene(0);

        }

    }

    void SpawnAnt()
    {
        //set the spawnpoint at one of the locations set in the inspector
        GameObject spawnPoint = spawnPoints[(Random.Range(0, 4))];
       
        GameObject newAnt = Instantiate(ant, spawnPoint.transform.position, Quaternion.identity);
        //set the new ant speed based on the time in the game
        newAnt.GetComponent<Squish>().speed = antSpeed;
        // set the parent the canvas so it appears on the screen and has the button function on it
        newAnt.transform.SetParent(gameObject.transform, true);
        
    }
}
