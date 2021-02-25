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

    public enum SpawnSide {Up, Down, Left, Right }

    public SpawnSide spawnSide;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnFlyLeftSideSpawner()
    {
        while (canSpawnFlies)
        {
            GameObject rightFlyingMosquito = Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity) as GameObject;

            //Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity);
            if (spawnSide == SpawnSide.Left)
            //GameObject g = Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity) as GameObject;
            {
                rightFlyingMosquito.GetComponent<MosquitoStats>().flydirection = MosquitoStats.FlyDirection.Right;
                Debug.Log("SpawnFlyLeftSideSpawner Coro has been ran");
            }
            //yield return new WaitForSeconds(spawnTime);
            StopCoroutine("SpawnFlyLeftSideSpawner");
            yield return null;
        }
        yield return null;
        
    }

    IEnumerator SpawnFlyRightSideSpawner()
    {
        while (canSpawnFlies)
        {
            GameObject leftFlyingMosquito = Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity) as GameObject;

            //Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity);
            if (spawnSide == SpawnSide.Right)
            //GameObject g = Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity) as GameObject;
            {
                leftFlyingMosquito.GetComponent<MosquitoStats>().flydirection = MosquitoStats.FlyDirection.Left;
                Debug.Log("SpawnFlyRightSideSpawner Coro has been ran");
            }
            //yield return new WaitForSeconds(spawnTime);
            StopCoroutine("SpawnFlyRightSideSpawner");
            yield return null;
        }
        yield return null;
        
    }

    IEnumerator SpawnFlyUpSideSpawner()
    {
        while (canSpawnFlies)
        {
            GameObject downFlyingMosquito = Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity) as GameObject;

            //Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity);
            if (spawnSide == SpawnSide.Up)
            //GameObject g = Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity) as GameObject;
            {
                downFlyingMosquito.GetComponent<MosquitoStats>().flydirection = MosquitoStats.FlyDirection.Down;
                Debug.Log("SpawnFlyUpSideSpawner Coro has been ran");
            }
            //yield return new WaitForSeconds(spawnTime);
            StopCoroutine("SpawnFlyUpSideSpawner");
            yield return null;
        }
        yield return null;
        
    }

    IEnumerator SpawnFlyDownSideSpawner()
    {
        while (canSpawnFlies)
        {
            GameObject upFlyingMosquito = Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity) as GameObject;

            //Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity);
            if (spawnSide == SpawnSide.Down)
            //GameObject g = Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity) as GameObject;
            {
                upFlyingMosquito.GetComponent<MosquitoStats>().flydirection = MosquitoStats.FlyDirection.Up;
                Debug.Log("SpawnFlyDownSideSpawner Coro has been ran");
            }
            //yield return new WaitForSeconds(spawnTime);
            StopCoroutine("SpawnFlyDownSideSpawner");
            yield return null;
        }
        yield return null;
        
    }
}
