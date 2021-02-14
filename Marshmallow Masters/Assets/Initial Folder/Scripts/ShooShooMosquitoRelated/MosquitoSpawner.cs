using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoSpawner : MonoBehaviour
{
    public float spawnTime;

    public float spawnRangeX1;
    public float spawnRangeX2;
    public float spawnRangeY1;
    public float spawnRangeY2;

    public bool canSpawnFlies;
    public GameObject flyPrefab;

    public enum SpawnDirection {Up, Down, Left, Right }

    public SpawnDirection spawnDirection;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("SpawnFly");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnFly()
    {
        while (canSpawnFlies)
        {
            Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity);
            if (spawnDirection == SpawnDirection.Right)
                flyPrefab.GetComponent<MosquitoMovement>().flydirection = MosquitoMovement.FlyDirection.Right;
            else if (spawnDirection == SpawnDirection.Left)
                flyPrefab.GetComponent<MosquitoMovement>().flydirection = MosquitoMovement.FlyDirection.Left;
            else if (spawnDirection == SpawnDirection.Up)
                flyPrefab.GetComponent<MosquitoMovement>().flydirection = MosquitoMovement.FlyDirection.Up;
            else if (spawnDirection == SpawnDirection.Down)
                flyPrefab.GetComponent<MosquitoMovement>().flydirection = MosquitoMovement.FlyDirection.Down;


            yield return new WaitForSeconds(spawnTime);
            yield return null;
        }
        yield return null;
    }

   
}
