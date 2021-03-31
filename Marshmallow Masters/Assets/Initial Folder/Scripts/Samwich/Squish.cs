using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squish : MonoBehaviour
{
    public float speed = 1f;
    private GameObject AntSpawn;
    public GameObject squishSound;
    private GameObject screenShake;
    // Update is called once per frame

    private void Start()
    {
        AntSpawn = GameObject.Find("Canvas");
        screenShake = GameObject.Find("ScreenShake");
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        
    }

    private void Update()
    {
       
        if (transform.position.y < -600f)
        {
            Debug.Log("Past -600");
            Destroy(gameObject);
        }
    }

    public void squish()
    {
        Instantiate(squishSound);
        Destroy(gameObject);

    }

   
    private void OnTriggerEnter(Collider other)
    {
        screenShake.GetComponent<ScreenShake>().shakeScreen(new Vector3(0.5f,0.5f,0.5f), 1);
        AntSpawn.GetComponent<AntSpawner>().lives--;
        Destroy(gameObject);
    }
}
