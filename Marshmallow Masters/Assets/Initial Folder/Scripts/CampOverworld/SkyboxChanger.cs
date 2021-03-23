using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material daySkybox;
    public Material nightSkybox;

    public float timer = 60;
    public float changeTime;
    private float fixedNumber;
    // Start is called before the first frame update
    void Start()
    {
        fixedNumber = timer;
        RenderSettings.skybox = daySkybox;
    }

    // Update is called once per frame
    void Update()
    {
       
        timer -= Time.deltaTime;

        if (timer < changeTime)
        {
            RenderSettings.skybox = nightSkybox;
        }
        if (timer < 0) 
        {
            RenderSettings.skybox = daySkybox;
            timer = fixedNumber; 
        }

    }

   
}
