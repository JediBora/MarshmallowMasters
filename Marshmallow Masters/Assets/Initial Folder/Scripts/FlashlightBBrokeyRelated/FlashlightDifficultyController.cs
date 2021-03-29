using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightDifficultyController : MonoBehaviour
{
    public PlayerFlashlightStats flashlightStats;

    public bool difficultyOne;
    public bool difficultyTwo;
    public bool difficultyThree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (difficultyOne)
        {
            DifficultyOneActive();
        }

        else if (difficultyTwo)
        {
            DifficultyTwoActive();
        }

        else if (difficultyThree)
        {
            DifficultyThreeActive();
        }
    }

    public void DifficultyOneActive()
    {
        flashlightStats.minSanity = 0;
        flashlightStats.maxSanity = 100;

        flashlightStats.minBattery = 0;
        flashlightStats.maxBattery = 100;

        //STuff
        //Starting Stats
        flashlightStats.sanity = 50;
        flashlightStats.flashlightBattery = 80;


        flashlightStats.gainSanityRate = 4;
        flashlightStats.loseSanityRate = 2;

        flashlightStats.gainFlashlightBatteryRate = 5;
        flashlightStats.loseFlashlightBatteryRate = 3;
    }

    public void DifficultyTwoActive()
    {
        flashlightStats.minSanity = 0;
        flashlightStats.maxSanity = 100;

        flashlightStats.minBattery = 0;
        flashlightStats.maxBattery = 100;

        //STuff
        //Starting Stats
        flashlightStats.sanity = 30;
        flashlightStats.flashlightBattery = 50;


        flashlightStats.gainSanityRate = 2.5f;
        flashlightStats.loseSanityRate = 3;

        flashlightStats.gainFlashlightBatteryRate = 3;
        flashlightStats.loseFlashlightBatteryRate = 4.5f;
    }

    public void DifficultyThreeActive()
    {
        flashlightStats.minSanity = 0;
        flashlightStats.maxSanity = 100;

        flashlightStats.minBattery = 0;
        flashlightStats.maxBattery = 100;

        //STuff
        //Starting Stats
        flashlightStats.sanity = 15;
        flashlightStats.flashlightBattery = 25;


        flashlightStats.gainSanityRate = 1.5f;
        flashlightStats.loseSanityRate = 5;

        flashlightStats.gainFlashlightBatteryRate = 1.5f;
        flashlightStats.loseFlashlightBatteryRate = 7;
    }
}
