using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

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
    }

    void SpawnAnt()
    {
        GameObject spawnPoint = spawnPoints[(Random.Range(0, 4))];
        Debug.Log(spawnPoint);
        GameObject newAnt = Instantiate(ant, spawnPoint.transform.position, Quaternion.identity);
        newAnt.GetComponent<Squish>().speed = antSpeed;

        newAnt.transform.parent = gameObject.transform;
    }
}
