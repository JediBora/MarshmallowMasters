using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooShooMosquitoGameManger : MonoBehaviour
{
    public int mosquitosSwatted;
    public float timePassed;
    public int lives;
    public float survivalTime;

    [Header("This is Updated Automatically")]
    public float timeToSurvive;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        timeToSurvive = survivalTime - timePassed;
    }
}
