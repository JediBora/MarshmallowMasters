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
        flashlightStats.sanity = 40;
        flashlightStats.flashlightBattery = 60;


        flashlightStats.gainSanityRate = 3f;
        flashlightStats.loseSanityRate = 2.5f;

        flashlightStats.gainFlashlightBatteryRate = 3.5f;
        flashlightStats.loseFlashlightBatteryRate = 4;
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
        flashlightStats.sanity = 25;
        flashlightStats.flashlightBattery = 45;


        flashlightStats.gainSanityRate = 2.4f;
        flashlightStats.loseSanityRate = 3;

        flashlightStats.gainFlashlightBatteryRate = 2.8f;
        flashlightStats.loseFlashlightBatteryRate = 4.5f;
    }
}
