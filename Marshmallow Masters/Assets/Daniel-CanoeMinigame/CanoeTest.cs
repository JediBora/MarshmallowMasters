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
    public Text RotZDisplay;

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
        /*
        //rotZ += Input.gyro.rotationRateUnbiased.z;
        rotZ += Input.gyro.rotationRateUnbiased.z;


        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Working");
            rb.AddTorque(transform.forward * forceToAdd, ForceMode.VelocityChange);
        }

        RotZDisplay.text = "Rot Z = " + rotZ.ToString("F2");
        */

        Quaternion referenceRotation = Quaternion.identity;
        Quaternion deviceRotation = new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0); //DeviceRotation.Get();
        Quaternion eliminationOfXY = Quaternion.Inverse(Quaternion.FromToRotation(referenceRotation * Vector3.forward, deviceRotation * Vector3.forward));
        Quaternion rotationZ = eliminationOfXY * deviceRotation;
        rotZ = rotationZ.eulerAngles.z;

        RotZDisplay.text = "Rot Z = " + rotZ.ToString("F2");
    }

    /*
    void Temp()
    {
        private static bool gyroInitialized = false;

    public static bool HasGyroscope
    {
        get
        {
            return SystemInfo.supportsGyroscope;
        }
    }

    public static Quaternion Get()
    {
        if (!gyroInitialized)
        {
            InitGyro();
        }

        return HasGyroscope
            ? ReadGyroscopeRotation()
            : Quaternion.identity;
    }

    private static void InitGyro()
    {
        if (HasGyroscope)
        {
            Input.gyro.enabled = true;                // enable the gyroscope
            Input.gyro.updateInterval = 0.0167f;    // set the update interval to it's highest value (60 Hz)
        }
        gyroInitialized = true;
    }

    private static Quaternion ReadGyroscopeRotation()
    {
        return new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
    }
}

    }
*/
}
