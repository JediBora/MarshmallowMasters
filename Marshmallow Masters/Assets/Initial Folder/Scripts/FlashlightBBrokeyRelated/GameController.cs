using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ShakeDetector shakeDetector;
    public PlayerFlashlightStats flashlightStats;


    //The time limit (in seconds)
    public float maxTime;
    //The time (in seconds)
    public float timePassing;

    public bool wentInsane;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        flashlightStats.sanity = Mathf.Clamp(flashlightStats.sanity, flashlightStats.minSanity, flashlightStats.maxSanity);
        flashlightStats.flashlightBattery = Mathf.Clamp(flashlightStats.flashlightBattery, flashlightStats.minBattery, flashlightStats.maxBattery);

        if (!wentInsane)
        {
            FlashlightIsShaking();
            TimerFunction();

        }
        
        
        if (flashlightStats.sanity <= 0)
        {

            wentInsane = true;
            Debug.Log("You lose");



        }

        //FlashlightIsShaking();





    }


    public void FlashlightIsShaking()
    {

        if (shakeDetector.deviceIsShaking)
        {
            flashlightStats.losingSanity = true;
            flashlightStats.flashlightLosingBattery = false;

            flashlightStats.flashlightBattery += flashlightStats.gainFlashlightBatteryRate * Time.deltaTime;

            flashlightStats.sanity -= flashlightStats.loseSanityRate * Time.deltaTime;


        }
        else if (!shakeDetector.deviceIsShaking && flashlightStats.flashlightBattery > 0)
        {
            flashlightStats.losingSanity = false;
            flashlightStats.flashlightLosingBattery = true;

            flashlightStats.flashlightBattery -= flashlightStats.loseFlashlightBatteryRate * Time.deltaTime;

            flashlightStats.sanity += flashlightStats.gainSanityRate * Time.deltaTime;

        }
        else if (!shakeDetector.deviceIsShaking && flashlightStats.flashlightBattery <= 0)
        {
            flashlightStats.losingSanity = true;

            flashlightStats.sanity -= flashlightStats.loseSanityRate * Time.deltaTime;


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

        Debug.Log("You win.");
        //Only use if timer needs to be reset
        //timePassing = 0;
    }

}
