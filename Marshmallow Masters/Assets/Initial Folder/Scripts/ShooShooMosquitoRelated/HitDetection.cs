using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public ShooShooMosquitoGameManger gameManager;
    public MosquitoStats mosquitoStats;

    //Flash enemy red
    public float flashTime;
    Color origionalColor;
    public MeshRenderer renderer;

    public FlashlightSounds soundManager;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<FlashlightSounds>();

        renderer = GetComponent<MeshRenderer>();

        origionalColor = renderer.material.color;
        //Don't use find in start cause scary
        if (GameObject.Find("GameManager") != null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<ShooShooMosquitoGameManger>();

        }

        mosquitoStats = GetComponent<MosquitoStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FlashRed()
    {
        renderer.material.color = Color.red;
        Invoke("ResetColor", flashTime);
    }
    void ResetColor()
    {
        renderer.material.color = origionalColor;
    }

    public void OnTriggerEnter(Collider other)
    {
        mosquitoStats.mosquitoHP -= 1;
        FlashRed();
        if (mosquitoStats.mosquitoHP <= 0)
        {
            Debug.Log("Mosquitos Hit: " + gameManager.mosquitosSwatted);
            soundManager.mosquitoDeathSound = true;
            gameManager.mosquitosSwatted += 1;
            Destroy(gameObject);
        }
    }
}
