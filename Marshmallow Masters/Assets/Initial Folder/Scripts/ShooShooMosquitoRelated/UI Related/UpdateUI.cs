using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    public TextMeshProUGUI lives;

    public TextMeshProUGUI mosquitoesKilled;

    public TextMeshProUGUI timeLeft;

    public ShooShooMosquitoGameManger gameManager;



    // Update is called once per frame
    void Update()
    {
        mosquitoesKilled.text = "Mosquito Killstreak: " +gameManager.mosquitosSwatted;
        lives.text = "Lives: " + gameManager.lives;
        timeLeft.text = "Time Left: " + gameManager.timeToSurvive.ToString("F0");
    }
}
