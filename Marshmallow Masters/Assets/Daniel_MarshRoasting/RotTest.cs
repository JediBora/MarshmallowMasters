using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotTest : MonoBehaviour
{
    public bool rotateX, rotateY, rotateZ;
    public float xAngle, yAngle, zAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateX)
        {
            transform.RotateAround(transform.position, transform.right, xAngle * Time.deltaTime);
        }

        if (rotateY)
        {
            transform.RotateAround(transform.position, transform.up, yAngle * Time.deltaTime);
        }

        if (rotateZ)
        {
            transform.RotateAround(transform.position, Vector3.forward, zAngle * Time.deltaTime);
        }
    }
}
