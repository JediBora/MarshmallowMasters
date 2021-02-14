using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoMovement : MonoBehaviour
{

    public Transform transform;
    public float mosquitoSpeed;


    public float lifetime;
    public float maxLifetime;

    public enum FlyDirection {Up, Down, Left, Right }

    public FlyDirection flydirection;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(gameObject);
        }

    }
}
