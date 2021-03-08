using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarManager : MonoBehaviour
{
    [Header("Scripts")]
    public PlayerFlashlightStats playerStats;
    public GameController gameController;


    [Header("Bars")]
    public Slider sanityBar;
    public Slider batteryBar;
    public Slider exitBar;

    [Header("Text")]
    public TMP_Text batteryText;
    public TMP_Text sanityText;


    // Start is called before the first frame update
    void Start()
    {
        sanityBar.maxValue = playerStats.maxSanity;
        sanityBar.value = playerStats.sanity;

        batteryBar.maxValue = playerStats.maxBattery;
        batteryBar.value = playerStats.flashlightBattery;

        exitBar.maxValue = gameController.maxTime;
        exitBar.value = gameController.timePassing;

        batteryText.text = playerStats.flashlightBattery + "%";
        sanityText.text = playerStats.sanity + "";
    }

    // Update is called once per frame
    void Update()
    {
        sanityBar.value = playerStats.sanity;
        batteryBar.value = playerStats.flashlightBattery;
        exitBar.value = gameController.timePassing;

        batteryText.text = playerStats.flashlightBattery.ToString("F0") + "%";
        sanityText.text = playerStats.sanity.ToString("F0") + "";
    }
}
