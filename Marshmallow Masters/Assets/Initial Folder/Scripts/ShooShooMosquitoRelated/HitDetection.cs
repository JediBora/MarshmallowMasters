using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public ShooShooMosquitoGameManger gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //Don't use find in start cause scary
        if (GameObject.Find("GameManager") != null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<ShooShooMosquitoGameManger>();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Mosquitos Hit: " + gameManager.mosquitosSwatted);
        gameManager.mosquitosSwatted += 1;
        Destroy(gameObject);
    }
}
