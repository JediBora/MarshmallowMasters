using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanoeTest : MonoBehaviour
{
    Rigidbody rb;
    public float forceToAdd;
    Gyroscope gyro;
    float rotZ;
    public Text rotRateDisplay, RotZDisplay;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        rotZ += gyro.rotationRateUnbiased.z;

        RotZDisplay.text = "Rot Z = " + rotZ.ToString("F2");
        rotRateDisplay.text = "rRate = " + gyro.rotationRateUnbiased;

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Working");
            rb.AddTorque(transform.forward * forceToAdd, ForceMode.VelocityChange);
        }

    }

}
