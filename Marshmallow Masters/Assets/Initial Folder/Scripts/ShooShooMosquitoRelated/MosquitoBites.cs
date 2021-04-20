using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoBites : MonoBehaviour
{
    public ShooShooMosquitoGameManger gameManger;


    public void OnTriggerEnter(Collider other)
    {
        gameManger.lives -= 1;



    }

}
