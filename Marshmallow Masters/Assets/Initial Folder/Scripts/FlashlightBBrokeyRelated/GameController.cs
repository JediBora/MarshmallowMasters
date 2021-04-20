using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public ShakeDetector shakeDetector;
    public PlayerFlashlightStats flashlightStats;


    //The time limit (in seconds)
    public float maxTime;
    //The time (in seconds)
    public float timePassing;

    public bool wentInsane;
    public bool outOfForest;

    public TMP_Text winLossText;

    // Start is called before the first frame update
    void Start()
    {
        winLossText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        flashlightStats.sanity = Mathf.Clamp(flashlightStats.sanity, flashlightStats.minSanity, flashlightStats.maxSanity);
        flashlightStats.flashlightBattery = Mathf.Clamp(flashlightStats.flashlightBattery, flashlightStats.minBattery, flashlightStats.maxBattery);

        if (!wentInsane && !outOfForest)
        {
            FlashlightIsShaking();
            TimerFunction();

        }
        
        
        if (flashlightStats.sanity <= 0)
        {

            wentInsane = true;
            winLossText.text = "You Lose";
            Debug.Log("You lose");



        }






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
        outOfForest = true;
        winLossText.text = "You made it out!";
        Debug.Log("You win.");
        //Only use if timer needs to be reset
        //timePassing = 0;
    }

}
