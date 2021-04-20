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
    public Material fly1;
    public Material fly2;

    public enum SpawnSide {Up, Down, Left, Right }

    public SpawnSide spawnSide;
    public MosquitoSpawnerManager mosquitoSpawner;


    IEnumerator SpawnFlyLeftSideSpawner()
    {
        while (canSpawnFlies)
        {
         
                GameObject rightFlyingMosquito = Instantiate(flyPrefab, new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), Random.Range(spawnRangeY1, spawnRangeY2), 0), Quaternion.identity) as GameObject;
                
            if (rightFlyingMosquito.GetComponent<MosquitoStats>().mosquitoHP == 1)
            {
                rightFlyingMosquito.transform.GetChild(0).GetComponent<Renderer>().material = fly1;
            }
            else
            {
                rightFlyingMosquito.transform.GetChild(0).GetComponentInChildren<Renderer>().material = fly2;
            }
            if (spawnSide == SpawnSide.Left)
            {
                rightFlyingMosquito.GetComponent<MosquitoStats>().flydirection = MosquitoStats.FlyDirection.Right;
                Debug.Log("SpawnFlyLeftSideSpawner Coro has been ran");
            }
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
            
            if (leftFlyingMosquito.GetComponent<MosquitoStats>().mosquitoHP == 1)
            {
                leftFlyingMosquito.transform.GetChild(0).GetComponentInChildren<Renderer>().material = fly1;
            }
            else
            {
                leftFlyingMosquito.transform.GetChild(0).GetComponentInChildren<Renderer>().material = fly2;
            }
            

            if (spawnSide == SpawnSide.Right)
            {
                leftFlyingMosquito.GetComponent<MosquitoStats>().flydirection = MosquitoStats.FlyDirection.Left;
                Debug.Log("SpawnFlyRightSideSpawner Coro has been ran");
            }
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

            if (downFlyingMosquito.GetComponent<MosquitoStats>().mosquitoHP == 1)
            {
                downFlyingMosquito.transform.GetChild(0).GetComponentInChildren<Renderer>().material = fly1;
            }
            else
            {
                downFlyingMosquito.transform.GetChild(0).GetComponentInChildren<Renderer>().material = fly2;
            }

            if (spawnSide == SpawnSide.Up)
            {
                downFlyingMosquito.GetComponent<MosquitoStats>().flydirection = MosquitoStats.FlyDirection.Down;
                Debug.Log("SpawnFlyUpSideSpawner Coro has been ran");
            }
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

            if (upFlyingMosquito.GetComponent<MosquitoStats>().mosquitoHP == 1)
            {
                upFlyingMosquito.transform.GetChild(0).GetComponentInChildren<Renderer>().material = fly1;
            }
            else
            {
                upFlyingMosquito.transform.GetChild(0).GetComponentInChildren<Renderer>().material = fly2;
            }
            if (spawnSide == SpawnSide.Down)
            {
                upFlyingMosquito.GetComponent<MosquitoStats>().flydirection = MosquitoStats.FlyDirection.Up;
                Debug.Log("SpawnFlyDownSideSpawner Coro has been ran");
            }
            StopCoroutine("SpawnFlyDownSideSpawner");
            yield return null;
        }
        yield return null;
        
    }
}
