using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public GameObject ant;
    public float timerEnd = 3;
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
        }
    }

    void SpawnAnt()
    {
        GameObject spawnPoint = spawnPoints[(Random.Range(0, 4))];
        Debug.Log(spawnPoint);
        GameObject newAnt = Instantiate(ant, spawnPoint.transform.position, Quaternion.identity);

        newAnt.transform.parent = gameObject.transform;
    }
}
