using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightShake : MonoBehaviour
{
    public GameObject gameManager;
    public ShakeDetector shakeDetector;
    public PlayerFlashlightStats flashStats;

    public GameObject flashlight;

    public GameObject flashlightShakePositionA;
    public GameObject flashlightShakePositionB;
    public float shakeFlashlightInterval;
    public float idkWhatThisIsTBH;


    public bool isIncreasing;

    [Header("Flashlight Initial Positions")]
    //Flashlight Initial Positions
    public Vector3 initialFlashlightPosition;
    public Quaternion initialFlashlightRotation;

    [Header("Flashlight On Positions")]
    //Flashlight On Positions
    public Vector3 lightOnPosition;
    public Quaternion lightOnRotation;

    [Header("Flashlight Off Positions")]
    //Flashlight Off Positions
    public Vector3 lightOffPosition;
    public Quaternion lightOffRotation;



    // Start is called before the first frame update
    void Start()
    {
        //lightOnPosition = flashlight.transform.position;
        //lightOnRotation = flashlight.transform.rotation;

        lightOnPosition = initialFlashlightPosition;
        lightOnRotation = initialFlashlightRotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (!shakeDetector.deviceIsShaking && flashStats.flashlightBattery > 0)
        {
            Debug.Log("Device is not shaking.");
            FlashlightOnWalk();
        }
        else if (shakeDetector.deviceIsShaking)
        {
            FlashlightOffShake();
            Debug.Log("Device is shaking.");
        }

    }



    public void FlashlightOnWalk()
    {
        flashlight.transform.position = lightOnPosition;
        flashlight.transform.rotation = lightOnRotation;



    }

    public void FlashlightOffShake()
    {

        if (isIncreasing)
        {
            idkWhatThisIsTBH += shakeFlashlightInterval * Time.deltaTime;

            if (idkWhatThisIsTBH >= 1)
            {
                isIncreasing = false;
            }
        }
        else if(!isIncreasing)
        {
            idkWhatThisIsTBH -= shakeFlashlightInterval * Time.deltaTime;

            if (idkWhatThisIsTBH <= 0)
            {
                isIncreasing = true;
            }
        }


        //flashlight.transform.position = lightOffPosition;
        flashlight.transform.rotation = lightOffRotation;


        flashlight.transform.position = Vector3.Lerp(flashlightShakePositionA.transform.position, flashlightShakePositionB.transform.position, idkWhatThisIsTBH);
        //iTween.ShakePosition(flashlight, cameraShakeIntensity, cameraShakeDuration);
    }

    public void FlashlightOffNoShake()
    {



    }


}
