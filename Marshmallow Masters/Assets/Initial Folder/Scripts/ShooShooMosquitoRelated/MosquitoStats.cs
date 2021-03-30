using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoStats : MonoBehaviour
{

    public GameObject camera;
    public Vector3 cameraShakeIntensity;
    public float cameraShakeDuration;

    public Transform transform;
    public float mosquitoSpeed;

    public float levelOneMinSpeed;
    public float levelOneMaxSpeed;

    public float levelTwoMinSpeed;
    public float levelTwoMaxSpeed;

    public float levelThreeMinSpeed;
    public float levelThreeMaxSpeed;


    public int mosquitoHP;

    public float lifetime;
    public float maxLifetime;

    public ShooShooMosquitoGameManger gameManager;
    public MosquitoSpawnerManager mosquitoSpawner;

    public enum FlyDirection {Up, Down, Left, Right }

    public FlyDirection flydirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //Don't use find in start cause scary
        if (GameObject.Find("GameManager") != null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<ShooShooMosquitoGameManger>();

        }

        if (GameObject.Find("Main Camera") != null)
        {
            camera = GameObject.Find("Main Camera");

        }

        if (GameObject.Find("GameManager") != null)
        {
            mosquitoSpawner = GameObject.Find("GameManager").GetComponent<MosquitoSpawnerManager>();

        }

        //Mosquito Health/Speed - GROVER
        if (mosquitoSpawner.levelOne)
        {
            mosquitoSpeed = (Random.Range(levelOneMinSpeed, levelOneMaxSpeed));
            mosquitoHP = 1;
        }
        else if (mosquitoSpawner.levelTwo)
        {
            mosquitoSpeed = (Random.Range(levelTwoMinSpeed, levelTwoMaxSpeed));
            mosquitoHP = (Random.Range(1, 3));
        }
        else if (mosquitoSpawner.levelThree)
        {
            mosquitoSpeed = (Random.Range(levelThreeMinSpeed, levelThreeMaxSpeed));
            mosquitoHP = (Random.Range(1, 1));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (flydirection == FlyDirection.Right)
            transform.position += new Vector3 (mosquitoSpeed, 0,0);
        else if (flydirection == FlyDirection.Left)
            transform.position -= new Vector3(mosquitoSpeed, 0, 0);
        else if (flydirection == FlyDirection.Up)
            transform.position += new Vector3(0, mosquitoSpeed, 0);
        else if (flydirection == FlyDirection.Down)
            transform.position -= new Vector3(0, mosquitoSpeed, 0);



        TimeAlive();
    }



    public void TimeAlive()
    {
        lifetime += Time.deltaTime;

        if (lifetime >= maxLifetime)
        {
            gameManager.lives -= 1;

            iTween.ShakePosition(camera, cameraShakeIntensity, cameraShakeDuration);

            Destroy(gameObject);
        }

    }
}
