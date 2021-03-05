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

            Debug.Log("I've been shooketh!");

        }



    }
}
