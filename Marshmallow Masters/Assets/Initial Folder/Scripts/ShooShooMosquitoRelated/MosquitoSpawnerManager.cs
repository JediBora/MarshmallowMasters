using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoSpawnerManager : MonoBehaviour
{
    public GameObject upSideSpawner;
    public GameObject downSideSpawner;
    public GameObject leftSideSpawner;
    public GameObject rightSideSpawner;

    public MosquitoSpawner mosquitoSpawnerL;
    public MosquitoSpawner mosquitoSpawnerR;
    public MosquitoSpawner mosquitoSpawnerU;
    public MosquitoSpawner mosquitoSpawnerD;


    public float spawnActivateTime;
    // Start is called before the first frame update
    void Start()
    {
        mosquitoSpawnerU = upSideSpawner.GetComponent<MosquitoSpawner>();
        mosquitoSpawnerD = downSideSpawner.GetComponent<MosquitoSpawner>();
        mosquitoSpawnerL = leftSideSpawner.GetComponent<MosquitoSpawner>();
        mosquitoSpawnerR = rightSideSpawner.GetComponent<MosquitoSpawner>();

    }

    public void Awake()
    {

        StartCoroutine("ActivateSpawners");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ActivateSpawners()
    {
        yield return new WaitForSeconds(spawnActivateTime);
        mosquitoSpawnerU.canSpawnFlies = true;
        yield return new WaitForSeconds(spawnActivateTime);
        mosquitoSpawnerU.StartCoroutine("SpawnFly");
        yield return new WaitForSeconds(spawnActivateTime);
        mosquitoSpawnerD.canSpawnFlies = true;
        yield return new WaitForSeconds(spawnActivateTime);
        mosquitoSpawnerD.StartCoroutine("SpawnFly");
        yield return new WaitForSeconds(spawnActivateTime);
        mosquitoSpawnerL.canSpawnFlies = true;
        yield return new WaitForSeconds(spawnActivateTime);
        mosquitoSpawnerL.StartCoroutine("SpawnFly");
        yield return new WaitForSeconds(spawnActivateTime);
        mosquitoSpawnerR.canSpawnFlies = true;
        yield return new WaitForSeconds(spawnActivateTime);
        mosquitoSpawnerR.StartCoroutine("SpawnFly");
        yield return new WaitForSeconds(spawnActivateTime);
    }

}
