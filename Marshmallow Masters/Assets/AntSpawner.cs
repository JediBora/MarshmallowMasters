using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public GameObject ant;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAnt();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void SpawnAnt()
    {
        GameObject spawnPoint = spawnPoints[(Random.Range(0, 3))];
        
        GameObject newAnt = Instantiate(ant, spawnPoint.transform.position, Quaternion.identity);

        newAnt.transform.parent = gameObject.transform;
    }
}
