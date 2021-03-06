using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShakeDetector : MonoBehaviour
{
    public float shakeDetectionThreshold;
    public float minimumShakeInterval;

    private float squareShakeDetectionThreshold;
    private float timeSinceLastShake;

    //Used in conjunction with Physics Controller
    //private PhysicsController physController;

    public bool deviceIsShaking;

    //Timer related
    //The time limit (in seconds)
    public float maxTime;
    //The time (in seconds)
    public float timePassing;

    // Start is called before the first frame update
    void Start()
    {
        squareShakeDetectionThreshold = Mathf.Pow(shakeDetectionThreshold, 2);

        //Used in conjunction with Physics Controller
        //physController = GetComponent<PhysicsController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.sqrMagnitude >= squareShakeDetectionThreshold && Time.unscaledTime >= timeSinceLastShake + minimumShakeInterval)
        {
            //Used in conjunction with Physics Controller
            //physController.ShakeRigidbodies(Input.acceleration);
            timeSinceLastShake = Time.unscaledTime;

            timePassing = 0;
            deviceIsShaking = true;
            Debug.Log("I've been shooketh!");

        }
        else
        {
            TimerFunction();
        }


    }

    void TimerFunction()
    {
        timePassing += Time.deltaTime;

        if (timePassing >= maxTime)
        {
            timerEnded();
        }
    }
    void timerEnded()
    {
        //Do your stuff here.
        deviceIsShaking = false;

        //Only use if timer needs to be reset
        //timePassing = 0;
    }

}
