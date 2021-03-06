using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlightStats : MonoBehaviour
{

    public float minSanity, maxSanity;
    public float minBattery, maxBattery;

    public float sanity;
    public float flashlightBattery;

    public float gainSanityRate;
    public float loseSanityRate;

    public float gainFlashlightBatteryRate;
    public float loseFlashlightBatteryRate;

    public bool losingSanity;
    public bool flashlightLosingBattery;

    public float gameEnd;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
