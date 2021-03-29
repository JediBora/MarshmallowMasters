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
        if (difficultyTwo)
            DifficultyTwoActive();
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
}
