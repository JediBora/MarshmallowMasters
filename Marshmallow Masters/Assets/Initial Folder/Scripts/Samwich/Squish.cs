using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squish : MonoBehaviour
{
    public float speed = 1f;
    private GameObject AntSpawn;
    // Update is called once per frame

    private void Start()
    {
        AntSpawn = GameObject.Find("Canvas");
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
        Destroy(gameObject);

    }

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        AntSpawn.GetComponent<AntSpawner>().lives--;
        Destroy(gameObject);
    }
}
