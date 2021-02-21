using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canoe : MonoBehaviour
{
    Rigidbody rb;
    public float forceToAdd;
    Gyroscope gyro;
    public float rotZ;
    public Text rotRateDisplay, RotZDisplay, tDisplay;
    public float maxTorque;
    public GUIStyle guiStyle;
    bool canMove = true;

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
        // *Influence the canoe with your tilt
        if (canMove)
        {
            rotZ += gyro.rotationRateUnbiased.z;
                rotZ = Mathf.Clamp(rotZ, -90f, 90f);

            if (rotZ >= 0)
            {
                float t = rotZ / 90;
                tDisplay.text = "t = " + t.ToString("F2");
                rb.AddTorque(transform.forward * Mathf.Lerp(0f, maxTorque, t), ForceMode.Force);
            }
            else
            {
                float t = rotZ / -90;
                tDisplay.text = "t = " + t.ToString("F2");
                rb.AddTorque(transform.forward * Mathf.Lerp(-maxTorque, 0f, t), ForceMode.Force);
            }

            RotZDisplay.text = "Rot Z = " + rotZ.ToString("F2");
        }

        //Check if canoe has flipped over
        if(transform.eulerAngles.z > 91 || transform.eulerAngles.z < -91)
        {
            //canMove = false;
        }


        //rb.AddTorque(transform.forward * forceToAdd, ForceMode.Force);

        /*
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Working");
            //print("The variable is :" + maxTorque); //Could use instead of Debug.Log
            rb.AddTorque(transform.forward * forceToAdd, ForceMode.VelocityChange);
        }
        */
    }

    public void HitWithWave(int strengthAndDirection)
    {
        Debug.Log("The canoe was hit with a mighty wave.");
        rb.AddTorque(transform.forward * strengthAndDirection, ForceMode.VelocityChange);
    }

    /*
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Lerp Result = " + maxTorque, guiStyle);
    }
    */

}
